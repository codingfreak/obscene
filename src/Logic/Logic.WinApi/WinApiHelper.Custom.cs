namespace codingfreaks.obscene.Logic.WinApi
{
    /// <summary>
    /// Provides internal access to Win32 API functions.
    /// </summary>
    internal static partial class WinApiHelper
    {
        #region methods

        /// <summary>
        /// Internal utility function to call <see cref="PostQuitMessage" /> or <see cref="DefWindowProc" /> depending on the
        /// <paramref name="msg" />.
        /// </summary>
        /// <param name="hWnd">The window handle.</param>
        /// <param name="msg">The message. If destroy is send then <see cref="PostQuitMessage" /> is used.</param>
        /// <param name="wParam">Parameters for <see cref="DefWindowProc" />.</param>
        /// <param name="lParam">Parameters for <see cref="DefWindowProc" />.</param>
        /// <returns>The result of <see cref="DefWindowProc" /> or NULL if the destroy message was sent.</returns>
        public static IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg == WinApiConstants.WM_DESTROY)
            {
                PostQuitMessage(0);
            }
            return DefWindowProc(hWnd, msg, wParam, lParam);
        }

        #endregion
    }
}
