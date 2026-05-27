// ReSharper disable InconsistentNaming

namespace codingfreaks.obscene.Ui.TestConsole
{
    using System.Drawing;

    using Logic.Abstracts.Interfaces;
    using Logic.Core.Geometries;

    /// <summary>
    /// Performs a simple circle drawing.
    /// </summary>
    internal static class Concept
    {
        #region methods

        public static void Demo(Action drawCallback)
        {
            var size = new Size(400, 400);
            var geometries = new List<IGeometry>
            {
                new Circle
                {
                    Size = size,
                    BorderColor = Color.Yellow,
                    Position = new Point(1200, 700)
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

        #endregion
    }
}
