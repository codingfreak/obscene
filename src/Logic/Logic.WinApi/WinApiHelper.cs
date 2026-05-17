namespace codingfreaks.obscene.Logic.WinApi
{
    using System.Runtime.InteropServices;

    using ApiTypes;

    /// <summary>
    /// Provides internal access to Win32 API functions.
    /// </summary>
    internal static class WinApiHelper
    {

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("user32.dll", EntryPoint = "CreateWindowExW", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateWindowEx(
            int dwExStyle,
            string lpClassName,
            string lpWindowName,
            int dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        [DllImport("user32.dll", EntryPoint = "DefWindowProcW", ExactSpelling = true)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll", EntryPoint = "DispatchMessageW", ExactSpelling = true)]
        public static extern IntPtr DispatchMessage(ref MSG lpMsg);

        public static IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg == WinApiConstants.WM_DESTROY)
            {
                PostQuitMessage(0);
            }
            return DefWindowProc(hWnd, msg, wParam, lParam);
        }

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetDC(IntPtr hwnd);

        // ─── Win32 P/Invoke ────────────────────────────────────────────────────────
        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GetModuleHandleW(IntPtr lpModuleName);

        [DllImport("user32.dll", EntryPoint = "PeekMessageW", ExactSpelling = true)]
        public static extern bool PeekMessage(
            ref MSG lpMsg,
            IntPtr hWnd,
            uint wMsgFilterMin,
            uint wMsgFilterMax,
            uint wRemoveMsg);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll", EntryPoint = "RegisterClassExW", ExactSpelling = true)]
        public static extern ushort RegisterClassEx(ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(
            IntPtr hwnd,
            IntPtr hdcDst,
            ref POINT pptDst,
            ref SIZE psize,
            IntPtr hdcSrc,
            ref POINT pptSrc,
            uint crKey,
            ref BLENDFUNCTION pblend,
            uint dwFlags);
    }
}