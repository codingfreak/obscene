// ReSharper disable InconsistentNaming

namespace codingfreaks.obscene.Ui.TestConsole
{
    using System.Drawing;

    using Logic.Abstracts.Interfaces;
    using Logic.Abstracts.Models;
    using Logic.Core.Geometries;
    using Logic.Obs;

    /// <summary>
    /// Performs a simple circle drawing.
    /// </summary>
    internal static class Concept
    {
        #region methods

        public static void Demo(Action drawCallback, Point position, int radius)
        {
            var size = new Size(radius, radius);
            var geometries = new List<IGeometry>
            {
                new Circle
                {
                    Size = size,
                    BorderColor = Color.Yellow,
                    Position = position
                },
                // new Circle
                // {
                //     Size = size,
                //     FillColor = Color.FromArgb(80, Color.Blue)
                // },
                // new Circle
                // {
                //     Size = size
                // }
            };
            //var offset = 0;
            foreach (var geo in geometries)
            {
                //offset += size.Width + 1000;
                //geo.Position = new Point(offset, 100);
                geo.Draw();
                geo.Refresh();
            }
            drawCallback.Invoke();
            foreach (var geo in geometries)
            {
                geo.Dispose();
            }
        }

        public static async ValueTask<Items> GetObsCameraSettingsAsync(string fileName, string sceneName, string deviceName)
        {
            var settings = await ObsHelper.LoadSettingsAsync(fileName);
            Console.WriteLine("Settings loaded.");
            var bottomRight = settings.sources.FirstOrDefault(s => s.name == sceneName);
            if (bottomRight == null)
            {
                throw new InvalidOperationException("Could not find scene.");
            }
            var cameraItem = bottomRight.settings.items.FirstOrDefault(i => i.name == deviceName);
            if (cameraItem == null)
            {
                throw new InvalidOperationException("Could not find camera device.");
            }
            return cameraItem;
        }

        #endregion
    }
}
