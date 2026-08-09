namespace codingfreaks.obscene.Ui.FormsApp
{
    using Logic.Core;
    using Logic.Obs;
    using Logic.Obs.Models;
    using Logic.WinApi;

    using Newtonsoft.Json.Linq;

    using OBSWebsocketDotNet;

    using System.Collections.Concurrent;

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
                        PutWindowToTray();
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

        /// <summary>
        /// Tries to connect to OBS.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Is thrown if this is called before <see cref="InitObsAsync" />.</exception>
        private async Task ConnectObsAsync()
        {
            if (_obs == null)
            {
                throw new InvalidOperationException("OBS is not initialized.");
            }
            var config = await Settings.LoadConfigAsync();
            if (string.IsNullOrEmpty(config.ObsPassword))
            {
                WriteStatusLabel("Cannot connect to OBS because no password is defined.");
                return;
            }
            var address = $"ws://localhost:{config.ObsPort}";
            WriteStatusLabel($"Trying to connect to OBS at '{address}'...");
            _obs.ConnectAsync(address, config.ObsPassword);
        }


        private void ExitObsenceContextCommand_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExitToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Ensures that all scenes are filled in the UI.
        /// </summary>
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

        private string? _currentSceneToReset;

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
                    _sceneLogic = new SceneLogic(_settings);
                    while (!token.IsCancellationRequested)
                    {
                        if (!_obs?.IsConnected ?? true)
                        {
                            if (!LastConnectionStateChangeHandled)
                            {
                                if (_sceneLogic.CurrentScene != null)
                                {
                                    _sceneLogic.Clear();
                                }
                                LastConnectionStateChangeHandled = true;
                            }
                        }
                        else
                        {
                            if (_sceneQueue.TryDequeue(out var sceneName))
                            {
                                if (!_settings.Scenes.ContainsKey(sceneName))
                                {
                                    WriteStatusLabel($"Unknown scene {sceneName} selected in OBS.");
                                    _sceneLogic.Clear();
                                    continue;
                                }
                                if (DrawingEnabled)
                                {
                                    if (_sceneLogic.CurrentScene != null && _sceneLogic.CurrentScene.Name == sceneName)
                                    {
                                        _sceneLogic.RefreshCurrentScene(
                                            _settings.Scenes[_sceneLogic.CurrentScene.Name]);
                                        WriteStatusLabel($"Scene {sceneName} was refreshed.");
                                    }
                                    else
                                    {
                                        _sceneLogic.Draw(sceneName);
                                        WriteStatusLabel($"obscene switched to scene {sceneName}.");
                                    }
                                }
                                else
                                {
                                    _currentSceneToReset = _sceneLogic.CurrentScene?.Name;
                                    _sceneLogic.Clear();
                                }
                            }
                            if (_handleDrawingEnabled)
                            {
                                if (DrawingEnabled)
                                {
                                    if (!string.IsNullOrEmpty(_currentSceneToReset))
                                    {
                                        _sceneLogic.Draw(_currentSceneToReset!);
                                        _currentSceneToReset = null;
                                    }
                                }
                                else
                                {
                                    _currentSceneToReset = _sceneLogic.CurrentScene?.Name;
                                    _sceneLogic.Clear();
                                }
                                _handleDrawingEnabled = false;
                            }
                        }
                        try
                        {
                            WaitForObsToComeAlive()
                                .GetAwaiter()
                                .GetResult();
                            Task.Delay(200, token)
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
                LastConnectionStateChangeHandled = false;
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
                LastConnectionStateChangeHandled = false;
                WriteCurrentSceneName(string.Empty);
                WriteStatusLabel("Disconnected from OBS.");
            };
            _obs.CurrentProgramSceneChanged += (_, args) =>
            {
                WriteCurrentSceneName(args.SceneName);
                WriteStatusLabel("OBS switched to scene.");
                _sceneQueue.Enqueue(args.SceneName);
            };
            await WriteStatusLabelAsync("Connecting to OBS...");
            await ConnectObsAsync();
            ReconnectObsToolStripButton.Enabled = true;
        }

        /// <summary>
        /// Loads the configuration from a file.
        /// </summary>
        private async Task LoadSettingsAsync()
        {
            _settings = await Settings.LoadAsync()
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
            try
            {
                _cancellationTokenSource.Cancel();
                _obs?.Disconnect();
                _queueWatcher?.Dispose();
            }
            catch
            {
                // we really cannot to anything here
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await InvokeAsync(SuspendLayout);
            await LoadSettingsAsync();
            await InitObsAsync();
            await FillObsScenesAsync();
            CheckActiveColorModelToolstripItem();
            GeometryHintLabel.Dock = DockStyle.Fill;
            GeometryHintLabel.Visible = true;
            if (!File.Exists(Settings.AppConfigFileName))
            {
                await OpenConfigDialogAsync();
            }
            var config = await Settings.LoadConfigAsync();
            if (!config.StartInTray)
            {
                RestoreWindowFromTray();
            }
            DrawingEnabledToolStripCheck.Image = MainImageList.Images["IconPause"];
            Visible = true;
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

        /// <summary>
        /// Opens the configuration dialog and handles its result.
        /// </summary>
        private async Task OpenConfigDialogAsync()
        {
            if (TopMost)
            {
                MessageBox.Show(
                    "Cannot open settings when Top Most is enabled.",
                    "Settings not available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            var settingsForm = new SettingsForm
            {
                StartPosition = FormStartPosition.CenterParent
            };
            var result = await settingsForm.ShowDialogAsync();
            if (result == DialogResult.OK)
            {
                WriteStatusLabel("Reconnecting to OBS...");
                _obs!.Disconnect();
                FillConfigScenes();
                await FillObsScenesAsync();
                await ConnectObsAsync();
            }
        }

        private void OpenObsceneContextCommand_Click(object sender, EventArgs e)
        {
            RestoreWindowFromTray();
        }

        /// <summary>
        /// Makes this window invisible.
        /// </summary>
        private void PutWindowToTray()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private async void ReconnectObsToolStripButton_Click(object sender, EventArgs e)
        {
            await ConnectObsAsync();
        }

        /// <summary>
        /// </summary>
        private void RestoreWindowFromTray()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        private async Task SaveSettingsAsync()
        {
            if (_settings == null)
            {
                return;
            }
            _settings.AppSettings.MainFormLocation = Location;
            _settings.AppSettings.MainFormSize = Size;
            _settings.AppSettings.TopMost = TopMost;
            _settings.AppSettings.IsDarkMode = ColorModeDarkItem.Checked;
            await _settings.SaveAsync();
            WriteStatusLabel("Settings saved.");
        }

        private async void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            await SaveSettingsAsync();
        }

        /// <summary>
        /// Reacts to the dark/light switch.
        /// </summary>
        /// <param name="sender">The control which triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <exception cref="InvalidOperationException">Is thrown if the sender is not a ToolStripMenuItem.</exception>
        private void SetColorMode(object sender, EventArgs e)
        {
            // NOTE: We need to sync this with whatever is currently selected
            var toolstrip = sender as ToolStripMenuItem;
            if (toolstrip == null)
            {
                // this should never happen!
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
            CheckActiveColorModelToolstripItem();
        }

        private async void SettingsToolStripDropDown_Click(object sender, EventArgs e)
        {
            await OpenConfigDialogAsync();
        }

        private void TopMostToolStripCheck_CheckStateChanged(object sender, EventArgs e)
        {
            TopMost = TopMostToolStripCheck.Checked;
        }

        private async Task WaitForObsToComeAlive()
        {
            while (!_obs?.IsConnected ?? true)
            {
                await Task.Delay(1000);
            }
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
        /// Indicates if the last OBS connection state change was handled or not.
        /// </summary>
        private bool LastConnectionStateChangeHandled { get; set; }

        private bool _handleDrawingEnabled = false;

        private void EnableDisableContextCommand_Click(object sender, EventArgs e)
        {
            DrawingEnabled = !DrawingEnabled;
        }

        private void DrawingEnabledToolStripCheck_Click(object sender, EventArgs e)
        {
            DrawingEnabled = !DrawingEnabled;
        }



        /// <summary>
        /// Indicates if obsence is drawing masks to the screen.
        /// </summary>
        private bool DrawingEnabled
        {
            get;
            set
            {
                field = value;
                _handleDrawingEnabled = true;
                EnableDisableContextCommand.Text = value ? "&Disable" : "&Enable";
                DrawingEnabledToolStripCheck.Image = value ? MainImageList.Images["IconPause"] : MainImageList.Images["IconPlay"];
            }
        } = true;

        #endregion
    }
}
