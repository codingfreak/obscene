namespace codingfreaks.obscene.Ui.FormsApp
{
    using System.Collections.Concurrent;

    using Logic.Core;
    using Logic.Obs;
    using Logic.Obs.Models;
    using Logic.WinApi;

    using Models;

    using OBSWebsocketDotNet;

    public partial class MainForm : Form
    {
        #region member vars

        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private readonly ConcurrentQueue<string> _sceneQueue = new();

        private bool _formClosingCalled;
        private OBSWebsocket? _obs;

        private Dictionary<string, ObsSceneSettings>? _obsSettings;
        private Task? _queueWatcher;

        private SceneLogic? _sceneLogic;
        private Settings? _settings;

        #endregion

        #region constructors and destructors

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region methods

        /// <inheritdoc />
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WinApiConstants.WM_NCLBUTTONDOWN)
            {
                switch ((int)m.WParam)
                {
                    case WinApiConstants.HTCLOSE:
                        WindowState = FormWindowState.Minimized;
                        ShowInTaskbar = false;
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void CheckActiveColorModelToolstripItem()
        {
            var currentColorMode = Application.ColorMode.ToString()
                .ToLowerInvariant();
            foreach (ToolStripMenuItem item in ColorModeContextMenu.Items)
            {
                item.Checked = item.Tag?.ToString()
                    ?.Equals(currentColorMode, StringComparison.OrdinalIgnoreCase) ?? false;
            }
        }

        private void ColorModeItem_Click(object sender, EventArgs e)
        {
            // NOTE: We need to sync this with whatever is currently selected
            var toolstrip = sender as ToolStripMenuItem;
            if (toolstrip == null)
            {
                throw new InvalidOperationException("Unkown sender.");
            }
            var text = toolstrip.Name!;
            if (text.Contains("dark", StringComparison.InvariantCultureIgnoreCase))
            {
                Application.SetColorMode(SystemColorMode.Dark);
            }
            else
            {
                Application.SetColorMode(SystemColorMode.Classic);
            }
            // Put the form in invisible mode and bring it up again to try to refresh the colors
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            // TODO This is not working relyable sadly
            Refresh();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = false;
            CheckActiveColorModelToolstripItem();
        }

        private void ConfigGeometriesList_SelectedValueChanged(object sender, EventArgs e)
        {
            GeometryProperties.SelectedObject = (ConfigGeometriesList.SelectedItem as GeometryListItem)?.Data;
        }

        private void ConfigSceneList_SelectedValueChanged(object sender, EventArgs e)
        {
            GeometryProperties.SelectedObject = null;
            ConfigGeometriesList.Items.Clear();
            if (_settings == null)
            {
                return;
            }
            var currentConfigKey = ConfigSceneList.SelectedItem?.ToString();
            if (!_settings.Scenes.ContainsKey(currentConfigKey ?? string.Empty))
            {
                return;
            }
            var currentConfigScene = _settings.Scenes[currentConfigKey!];
            var converted = currentConfigScene.Geometries.Select(g => new GeometryListItem
            {
                Label = g.GeometryType.ToString(),
                Data = g
            });
            foreach (var geometry in converted)
            {
                ConfigGeometriesList.Items.Add(geometry);
            }
        }

        private void ExitObsenceContextCommand_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FillConfigScenes()
        {
            if (_settings == null)
            {
                return;
            }
            Invoke(() =>
            {
                ConfigSceneList.Items.Clear();
                var keys = _settings.Scenes.Select(s => s.Key.ToString())
                    .Cast<object>()
                    .ToArray();
                ConfigSceneList.Items.AddRange(keys);
            });
        }

        /// <summary>
        /// TODO
        /// </summary>
        private async Task FillObsScenesAsync()
        {
            _obsSettings = await ObsHelper.LoadDefaultSceneSettingsAsync();
            await InvokeAsync(() =>
            {
                var keys = _obsSettings.Select(k => k.Key)
                    .Cast<object>()
                    .ToArray();
                ObsProfileSelect.Items.AddRange(keys);
                if (keys.Any())
                {
                    ObsProfileSelect.SelectedIndex = 0;
                }
            });
        }

        private void GeometryProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentSceneBarLabel.Text))
            {
                return;
            }
            _sceneLogic?.Draw(CurrentSceneBarLabel.Text);
        }

        private void HighlightCurrentScene()
        {
            Invoke(() =>
            {
                foreach (ListViewItem item in ObsSceneListView.Items)
                {
                    if (item.Text == CurrentSceneBarLabel.Text)
                    {
                        item.ForeColor = Color.Red;
                    }
                    else
                    {
                        item.ForeColor = ForeColor;
                    }
                }
            });
        }

        private async Task InitObsAsync()
        {
            if (_settings == null)
            {
                return;
            }
            var token = _cancellationTokenSource.Token;
            _queueWatcher = Task.Run(
                () =>
                {
                    _sceneLogic = new SceneLogic(_settings);
                    while (!token.IsCancellationRequested)
                    {
                        if (_sceneQueue.TryDequeue(out var sceneName))
                        {
                            if (!_settings.Scenes.ContainsKey(sceneName))
                            {
                                WriteStatusLabel($"Unknown scene {sceneName} selected in OBS.");
                                _sceneLogic.Clear();
                                continue;
                            }
                            _sceneLogic.Draw(sceneName);
                            WriteStatusLabel($"obscene switched to scene {sceneName}.");
                        }
                        try
                        {
                            Task.Delay(20, token)
                                .GetAwaiter()
                                .GetResult();
                        }
                        catch (TaskCanceledException)
                        {
                            break;
                        }
                    }
                },
                token);
            _obs = new OBSWebsocket();
            _obs.Connected += (sender, _) =>
            {
                var senderObs = sender as OBSWebsocket;
                if (senderObs == null)
                {
                    throw new InvalidOperationException("Strange things happened.");
                }
                var sceneName = senderObs.GetCurrentProgramScene();
                WriteCurrentSceneName(sceneName);
                _sceneQueue.Enqueue(sceneName);
                WriteStatusLabel("Connected to OBS.");
            };
            _obs.Disconnected += (_, _) =>
            {
                WriteStatusLabel("Disconnected from OBS.");
            };
            _obs.CurrentProgramSceneChanged += (_, args) =>
            {
                WriteCurrentSceneName(args.SceneName);
                WriteStatusLabel("OBS switched to scene.");
                _sceneQueue.Enqueue(args.SceneName);
            };
            await WriteStatusLabelAsync("Connecting to OBS...");
            _obs.ConnectAsync(
                "ws://localhost:4455",
                Environment.GetEnvironmentVariable("Obs:Password")
                ?? Environment.GetEnvironmentVariable("OBS_PASSWORD"));
        }

        private async Task LoadConfigAsync()
        {
            var settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configs", "my.json");
            _settings = await Settings.LoadAsync(settingsPath)
                .ConfigureAwait(false);
            FillConfigScenes();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formClosingCalled = true;
            _cancellationTokenSource.Cancel();
            _obs?.Disconnect();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadConfigAsync();
            await InitObsAsync();
            await FillObsScenesAsync();
            CheckActiveColorModelToolstripItem();
        }

        private void ObsProfileSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObsSceneListView.Enabled = ObsProfileSelect.SelectedItem != null;
            ObsSceneListView.Items.Clear();
            if (_obsSettings == null)
            {
                // This should never happen :-)
                return;
            }
            var selectedProfile = ObsProfileSelect.SelectedItem?.ToString()!;
            var currentSettings = _obsSettings[selectedProfile];
            foreach (var scene in currentSettings.Scenes.Where(s => s.Id == "scene"))
            {
                var item = new ListViewItem
                {
                    Tag = scene.Id,
                    Text = scene.Name
                };
                item.SubItems.Add(scene.Uuid);
                ObsSceneListView.Items.Add(item);
            }
            ObsSceneListSummaryLabel.Text =
                $"{ObsSceneListView.Items.Count} scenes loaded from OBS profile '{selectedProfile}'.";
            HighlightCurrentScene();
        }

        private void OpenObsceneContextCommand_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private void WriteCurrentSceneName(string sceneName)
        {
            Invoke(() =>
            {
                CurrentSceneBarLabel.Text = sceneName;
            });
            HighlightCurrentScene();
        }

        private void WriteStatusLabel(string labelText, int durationInSeconds = 2)
        {
            if (_formClosingCalled)
            {
                return;
            }
            Invoke(() =>
            {
                StatusBarLabel.Text = labelText;
                if (durationInSeconds > 0)
                {
                    Task.Delay(TimeSpan.FromSeconds(durationInSeconds))
                        .ContinueWith(_ =>
                        {
                            Invoke(() => StatusBarLabel.Text = "Ready");
                        });
                }
            });
        }

        private async Task WriteStatusLabelAsync(string labelText)
        {
            if (_formClosingCalled)
            {
                return;
            }
            await InvokeAsync(() =>
            {
                StatusBarLabel.Text = labelText;
            });
        }

        #endregion
    }
}
