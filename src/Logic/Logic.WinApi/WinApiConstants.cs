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
        public const byte CircleAlpha = 128; // 0=invisible, 255=opaque (128 ≈ 50%)

        public const uint ULW_ALPHA = 0x02;

        public const uint WM_DESTROY = 0x0002;

        public const int WS_EX_LAYERED = 0x00080000;
        public const int WS_EX_TOOLWINDOW = 0x00000080; // hide from taskbar/Alt-Tab
        public const int WS_EX_TOPMOST = 0x00000008; // always on top
        public const int WS_EX_TRANSPARENT = 0x00000020; // click-through
        public const int WS_POPUP = unchecked((int)0x80000000);

        public static readonly Delegates.WndProcDelegate s_wndProc = WinApiHelper.WndProc;

        #endregion
    }
}