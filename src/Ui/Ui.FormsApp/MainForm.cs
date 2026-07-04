namespace codingfreaks.obscene.Ui.FormsApp
{
    using Logic.Core;
    using Logic.WinApi;

    using OBSWebsocketDotNet;

    public partial class MainForm : Form
    {
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

        private void ExitObsenceContextCommand_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formClosingCalled = true;
            _cancellationTokenSource.Cancel();
            _obs?.Disconnect();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configs", "my.json");
            _settings = await Settings.LoadAsync(settingsPath)
                .ConfigureAwait(false);
            var token = _cancellationTokenSource.Token;
            _queueWatcher = Task.Run(
                () =>
                {
                    var logic = new SceneLogic(_settings);
                    while (!token.IsCancellationRequested)
                    {
                        if (_sceneQueue.TryDequeue(out var sceneName))
                        {
                            if (!_settings.Scenes.ContainsKey(sceneName))
                            {
                                WriteStatusLabel($"Unknown scene {sceneName} selected in OBS.");
                                logic.Clear();
                                continue;
                            }
                            logic.Draw(sceneName);
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
            await FillObsScenesAsync();
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

        #endregion
    }
}
