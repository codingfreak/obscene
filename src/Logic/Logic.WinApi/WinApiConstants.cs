namespace codingfreaks.obscene.Logic.WinApi
{
    /// <summary>
    /// Provides internal access to Win32 constants.
    /// </summary>
    public static class WinApiConstants
    {
        #region constants

        public const byte AC_SRC_ALPHA = 0x01;

        public const byte AC_SRC_OVER = 0x00;

        /// <summary>
        /// 0=invisible, 255=opaque (128 ≈ 50%)
        /// </summary>
        public const byte CircleAlpha = 128;

        /// <summary>
        /// Don't activate the window.
        /// </summary>
        public const uint SWP_NOACTIVATE = 0x0010;

        /// <summary>
        /// Don't change width/height.
        /// </summary>
        public const uint SWP_NOSIZE = 0x0001;

        public const int SW_SHOWNORMAL = 1;

        /// <summary>
        /// Don't change z-order.
        /// </summary>
        public const uint SWP_NOZORDER = 0x0004;

        public const uint ULW_ALPHA = 0x02;

        public const uint WM_DESTROY = 0x0002;

        public const int WS_EX_LAYERED = 0x00080000;

        /// <summary>
        /// Hide from taskbar/Alt-Tab
        /// </summary>
        public const int WS_EX_TOOLWINDOW = 0x00000080;

        /// <summary>
        /// Always on top.
        /// </summary>
        public const int WS_EX_TOPMOST = 0x00000008;

        /// <summary>
        /// Click-through
        /// </summary>
        public const int WS_EX_TRANSPARENT = 0x00000020;

        public const int WS_POPUP = unchecked((int)0x80000000);

        public const int WM_NCLBUTTONDOWN = 0x00A1;

        public const int HTCLOSE = 20;

        public static readonly Delegates.WndProcDelegate s_wndProc = WinApiHelper.WndProc;

        #endregion
    }
}
