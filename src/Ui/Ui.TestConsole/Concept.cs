// ReSharper disable InconsistentNaming

namespace codingfreaks.obscene.Ui.TestConsole
{
    using System.Drawing;

    using Logic.WinApi;

    /// <summary>
    /// Performs a simple circle drawing.
    /// </summary>
    internal static class Concept
    {
        #region methods

        public static void Demo(Action drawCallback, Point position, Size size)
        {
            var windowContext = DrawingHelper.InitializeWindow(position, size);
            var info = DrawingHelper.DrawCircle(windowContext.Handle, position, size.Width, Color.Red, 50, Color.DarkRed);
            try
            {
                drawCallback.Invoke();
            }
            finally
            {
                DrawingHelper.CleanupWindow(info);
            }
        }

        #endregion
    }
}