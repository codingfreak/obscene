namespace codingfreaks.obscene.Ui.FormsApp
{
    using System.Collections.Concurrent;

    using Logic.Core;
    using Logic.Obs;
    using Logic.Obs.Models;

    using OBSWebsocketDotNet;

    partial class MainForm
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

        #region methods

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
