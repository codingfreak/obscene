namespace codingfreaks.obscene.Ui.FormsApp
{
    using Logic.Core;
    using Logic.WinApi;

    using System.Collections.Concurrent;

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

        private void OpenObsceneContextCommand_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        #endregion

        private Settings? _settings;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private ConcurrentQueue<string> _sceneQueue = new ConcurrentQueue<string>();
        private Task? _queueWatcher;

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var settingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configs", "my.json");
            _settings = await Settings.LoadAsync(settingsPath).ConfigureAwait(false);
            var token = _cancellationTokenSource.Token;
            _queueWatcher = Task.Run(() =>
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
                        Task.Delay(20, token).GetAwaiter().GetResult();
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }
                }
            }, token);
            var obs = new OBSWebsocket();
            obs.Connected += (sender, _) =>
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
            obs.Disconnected += (_, _) =>
            {
                StatusBarLabel.Text = "Disconnected from OBS.";
            };
            obs.CurrentProgramSceneChanged += (_, args) =>
            {
                StatusBarLabel.Text = $"OBS switched to scene {args.SceneName}";
                _sceneQueue.Enqueue(args.SceneName);
            };
            StatusBarLabel.Text = "Connecting to OBS...";
            obs.ConnectAsync("ws://localhost:4455", Environment.GetEnvironmentVariable("Obs:Password"));
        }
    }
}
