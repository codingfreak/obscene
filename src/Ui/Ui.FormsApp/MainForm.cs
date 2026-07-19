namespace codingfreaks.obscene.Ui.FormsApp
{
    using System.Collections.Concurrent;

    using Logic.Core;
    using Logic.Obs;
    using Logic.Obs.Models;
    using Logic.WinApi;

    using OBSWebsocketDotNet;

    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        #region member vars

        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private readonly ConcurrentQueue<string> _sceneQueue = new();

        private bool _formClosingCalled;
        private OBSWebsocket? _obs;

        private Dictionary<string, ObsSceneSettings>? _obsSettings;
        private Task? _queueWatcher;

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

        private void ConfigSceneTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            GeometryProperties.SelectedObject = null;
            if (e.Node?.Tag == null)
            {
                return;
            }
            GeometryProperties.SelectedObject = e.Node.Tag;
        }

        private void ExitObsenceContextCommand_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExitToolStripButton_Click(object sender, EventArgs e)
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
                // TreeView
                ConfigSceneTree.Nodes.Clear();
                ConfigSceneTree.Nodes.AddRange(
                    _settings.Scenes.Select(s =>
                        {
                            var node = new TreeNode(s.Key);
                            var nodeScene = _settings.Scenes[s.Key];
                            node.Nodes.AddRange(
                                nodeScene.Geometries.Select(g =>
                                    {
                                        var childNode = new TreeNode(g.GeometryType.ToString())
                                        {
                                            Tag = g
                                        };
                                        return childNode;
                                    })
                                    .ToArray());
                            return node;
                        })
                        .ToArray());
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
            if (_settings == null)
            {
                return;
            }
            _sceneQueue.Enqueue(CurrentSceneBarLabel.Text);
        }

        private void GeometryProperties_SelectedObjectsChanged(object sender, EventArgs e)
        {
            GeometryProperties.Visible = GeometryProperties.SelectedObject != null;
            GeometryHintLabel.Visible = !GeometryProperties.Visible;
        }

        /// <summary>
        /// Ensures that the scene selected in OBS is highlighted.
        /// </summary>
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

        /// <summary>
        /// Starts a background task which constantly syncs with changes in OBS scenes.
        /// </summary>
        /// <exception cref="InvalidOperationException">Is thrown if the sender of an OBS event is actually not resolved.</exception>
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
                    var sceneLogic = new SceneLogic(_settings);
                    while (!token.IsCancellationRequested)
                    {
                        if (_sceneQueue.TryDequeue(out var sceneName))
                        {
                            if (!_settings.Scenes.ContainsKey(sceneName))
                            {
                                WriteStatusLabel($"Unknown scene {sceneName} selected in OBS.");
                                sceneLogic.Clear();
                                continue;
                            }
                            if (sceneLogic.CurrentScene != null && sceneLogic.CurrentScene.Name == sceneName)
                            {
                                sceneLogic.RefreshCurrentScene(_settings.Scenes[sceneLogic.CurrentScene.Name]);
                                WriteStatusLabel($"Scene {sceneName} was refreshed.");
                            }
                            else
                            {
                                sceneLogic.Draw(sceneName);
                                WriteStatusLabel($"obscene switched to scene {sceneName}.");
                            }
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
            // TODO Get this from settings
            _obs.ConnectAsync(
                "ws://localhost:4455",
                Environment.GetEnvironmentVariable("Obs:Password")
                ?? Environment.GetEnvironmentVariable("OBS_PASSWORD"));
        }

        /// <summary>
        /// Loads the configuration from a file.
        /// </summary>
        private async Task LoadConfigAsync()
        {
            _settings = await Settings.LoadAsync(SettingsPath)
                .ConfigureAwait(false);
            // apply app settings
            await InvokeAsync(() =>
            {
                TopMost = _settings.AppSettings.TopMost;
                Location = _settings.AppSettings.MainFormLocation ?? Location;
                Size = _settings.AppSettings.MainFormSize ?? Size;
                // sync controls
                TopMostToolStripCheck.Checked = TopMost;
                SetColorMode(
                    _settings.AppSettings.IsDarkMode ? ColorModeDarkItem : ColorModeLightItem,
                    EventArgs.Empty);
            });
            FillConfigScenes();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formClosingCalled = true;
            _cancellationTokenSource.Cancel();
            _obs?.Disconnect();
            _queueWatcher?.Dispose();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await InvokeAsync(SuspendLayout);
            await LoadConfigAsync();
            await InitObsAsync();
            await FillObsScenesAsync();
            CheckActiveColorModelToolstripItem();
            GeometryHintLabel.Dock = DockStyle.Fill;
            GeometryHintLabel.Visible = true;
            await InvokeAsync(() => ResumeLayout(true));
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

        private async Task SaveConfigAsync()
        {
            if (_settings == null)
            {
                return;
            }
            _settings.AppSettings.MainFormLocation = Location;
            _settings.AppSettings.MainFormSize = Size;
            _settings.AppSettings.TopMost = TopMost;
            _settings.AppSettings.IsDarkMode = ColorModeDarkItem.Checked;
            await _settings.SaveAsync(SettingsPath);
            WriteStatusLabel("Settings saved.");
        }

        private async void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            await SaveConfigAsync();
        }

        private async void SetColorMode(object sender, EventArgs e)
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

        private async void SettingsToolStripDropDown_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
            await settingsForm.ShowDialogAsync();
        }

        private void TopMostToolStripCheck_CheckStateChanged(object sender, EventArgs e)
        {
            TopMost = TopMostToolStripCheck.Checked;
        }

        private void WriteCurrentSceneName(string sceneName)
        {
            Invoke(() =>
            {
                CurrentSceneBarLabel.Text = sceneName;
            });
            HighlightCurrentScene();
        }

        //private Task? _writeUpdater;

        /// <summary>
        /// Sets the content of the status label for the current activity to the given <paramref name="labelText" />.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use <see cref="WriteStatusLabelAsync" /> if you want to change the text permantently.
        /// </para>
        /// <para>
        /// Set <paramref name="durationInSeconds" /> to 0 in order to write permanent.
        /// </para>
        /// </remarks>
        /// <param name="labelText">The text to show.</param>
        /// <param name="durationInSeconds">Optional amount of time after which to switch back to the default text.</param>
        private void WriteStatusLabel(string labelText, int durationInSeconds = 2)
        {
            if (_formClosingCalled)
            {
                return;
            }
            Invoke(() =>
            {
                StatusBarLabel.Text = labelText;
            });
            if (durationInSeconds > 0)
            {
                Task.Delay(TimeSpan.FromSeconds(durationInSeconds))
                    .ContinueWith(_ =>
                    {
                        WriteStatusLabel("Ready", 0);
                    });
            }
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

        #region properties

        /// <summary>
        /// The path where the settings should be stored at and loaded from.
        /// </summary>
        /// <remarks>
        /// TODO: This needs to be checked.
        /// </remarks>
        private static string SettingsPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "obscene.json");

        #endregion
    }
}
