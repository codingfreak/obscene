// ReSharper disable InconsistentNaming

namespace codingfreaks.obscene.Ui.TestConsole
{
    using System.Drawing;

    using Logic.Core.Geometries;
    using Logic.WinApi;

    /// <summary>
    /// Performs a simple circle drawing.
    /// </summary>
    internal static class Concept
    {
        #region methods

        public static void Demo(Action drawCallback, Point position, Size size)
        {
            using (var circle = new Circle())
            {
                circle.Position = position;
                circle.Size = size;
                circle.Draw();
                drawCallback.Invoke();
            }
        }

        #endregion
    }
}