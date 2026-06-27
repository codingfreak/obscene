namespace codingfreaks.obscene.Ui.FormsApp
{
    using System.Collections.Concurrent;

    using Logic.Core;
    using Logic.WinApi;

    using OBSWebsocketDotNet;

    public partial class MainForm : Form
    {
        #region member vars

        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private readonly ConcurrentQueue<string> _sceneQueue = new();
        private OBSWebsocket? _obs;
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

        private void ExitObsenceContextCommand_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                                StatusBarLabel.Text = $"Unknown scene {sceneName} selected in OBS.";
                                logic.Clear();
                                continue;
                            }
                            logic.Draw(sceneName);
                            StatusBarLabel.Text = $"obscene switched to scene {sceneName}.";
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
                _sceneQueue.Enqueue(sceneName);
                StatusBarLabel.Text = "Connected to OBS.";
            };
            _obs.Disconnected += (_, _) =>
            {
                StatusBarLabel.Text = "Disconnected from OBS.";
            };
            _obs.CurrentProgramSceneChanged += (_, args) =>
            {
                StatusBarLabel.Text = $"OBS switched to scene {args.SceneName}";
                _sceneQueue.Enqueue(args.SceneName);
            };
            StatusBarLabel.Text = "Connecting to OBS...";
            _obs.ConnectAsync("ws://localhost:4455", Environment.GetEnvironmentVariable("Obs:Password") ?? Environment.GetEnvironmentVariable("OBS_PASSWORD"));
        }

        private void OpenObsceneContextCommand_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        #endregion
    }
}
