namespace codingfreaks.obscene.Ui.TestConsole
{
    using System.Drawing;

    using Logic.Abstracts.Interfaces;
    using Logic.Core.Geometries;
    using Logic.Obs;

    using Rectangle = Logic.Core.Geometries.Rectangle;

    /// <summary>
    /// Performs a simple circle drawing.
    /// </summary>
    internal static class Concept
    {
        #region methods

        public static void Demo(Action drawCallback, Point position, Size size)
        {
            var geometries = new List<IGeometry>
            {
                new Rectangle
                {
                    Size = size,
                    BorderColor = Color.Yellow,
                    Position = position
                }
            };
            //var offset = 0;
            foreach (var geo in geometries)
            {
                geo.Draw();
                geo.Refresh();
            }
            drawCallback.Invoke();
            foreach (var geo in geometries)
            {
                geo.Dispose();
            }
        }

        public static async Task DrawObsDeviceOverlayAsync(string path, string sceneName, string deviceName)
        {
            var camera = await ObsHelper.GetObsCameraSettingsAsync(path, sceneName, deviceName);
            var xOffset = 150;
            var yOffset = 20;
            var position = new Point((int)camera.Position.X + xOffset, (int)camera.Position.Y + yOffset);
            // We need to half the dimension because we are talking radius and not diameter!
            var size = new Size(
                (int)(camera.Scale.X * camera.ScaleReference.X) / 2,
                (int)(camera.Scale.Y * camera.ScaleReference.Y) / 2);
            using (var geo = new Rectangle())
            {
                geo.Position = position;
                geo.Size = size;
                geo.BorderColor = Color.Yellow;
                geo.BorderWidth = 2;
                geo.Draw();
                var run = true;
                Console.WriteLine(
                    "[+] Bigger | [-] Smaller | [\u2190] Left | [\u2191] Up | [\u2192] Right | [\u2193] Down | [ESC] Quit");
                while (run)
                {
                    var key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Add:
                            geo.Size = new Size(geo.Size.Width + 10, geo.Size.Height + 10);
                            break;
                        case ConsoleKey.Subtract:
                            geo.Size = new Size(geo.Size.Width - 10, geo.Size.Height - 10);
                            break;
                        case ConsoleKey.LeftArrow:
                            geo.Position = new Point(geo.Position.X - 10, geo.Position.Y);
                            break;
                        case ConsoleKey.RightArrow:
                            geo.Position = new Point(geo.Position.X + 10, geo.Position.Y);
                            break;
                        case ConsoleKey.UpArrow:
                            geo.Position = new Point(geo.Position.X, geo.Position.Y - 10);
                            break;
                        case ConsoleKey.DownArrow:
                            geo.Position = new Point(geo.Position.X, geo.Position.Y + 10);
                            break;
                        case ConsoleKey.Escape:
                            run = false;
                            break;
                    }
                }
            }
        }

        public static async Task DrawObsDeviceOverlayAsync(string deviceName, string? sceneName = null)
        {
            // try to load from default dir
            var allSettings = await ObsHelper.LoadDefaultSceneSettingsAsync();
            var settings = allSettings.FirstOrDefault()
                .Value;
            if (settings == null)
            {
                // default dir did not work -> try explicit one
                throw new InvalidOperationException("Could not find default settings.");
            }
            // default dir did work -> auto
            var resolvedSceneName = sceneName ?? settings.CurrentScene;
            var camera = settings.Scenes.FirstOrDefault(s => s.Name == resolvedSceneName)
                ?.Settings.Devices.FirstOrDefault(d => d.Name == deviceName);
            if (camera == null)
            {
                throw new InvalidOperationException("Could not find device.");
            }
            var xOffset = 150;
            var yOffset = 20;
            var position = new Point((int)camera.Position.X + xOffset, (int)camera.Position.Y + yOffset);
            // We need to half the dimension because we are talking radius and not diameter!
            var size = new Size(
                (int)(camera.Scale.X * camera.ScaleReference.X) / 2,
                (int)(camera.Scale.Y * camera.ScaleReference.Y) / 2);
            using (var geo = new Circle())
            {
                geo.Position = position;
                geo.Size = size;
                geo.BorderColor = Color.Yellow;
                geo.BorderWidth = 2;
                geo.Draw();
                var run = true;
                Console.WriteLine(
                    "[+] Bigger | [-] Smaller | [\u2190] Left | [\u2191] Up | [\u2192] Right | [\u2193] Down | [ESC] Quit");
                while (run)
                {
                    var key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Add:
                            geo.Size = new Size(geo.Size.Width + 10, geo.Size.Height + 10);
                            break;
                        case ConsoleKey.Subtract:
                            geo.Size = new Size(geo.Size.Width - 10, geo.Size.Height - 10);
                            break;
                        case ConsoleKey.LeftArrow:
                            geo.Position = new Point(geo.Position.X - 10, geo.Position.Y);
                            break;
                        case ConsoleKey.RightArrow:
                            geo.Position = new Point(geo.Position.X + 10, geo.Position.Y);
                            break;
                        case ConsoleKey.UpArrow:
                            geo.Position = new Point(geo.Position.X, geo.Position.Y - 10);
                            break;
                        case ConsoleKey.DownArrow:
                            geo.Position = new Point(geo.Position.X, geo.Position.Y + 10);
                            break;
                        case ConsoleKey.Escape:
                            run = false;
                            break;
                    }
                }
            }
        }

        #endregion
    }
}
