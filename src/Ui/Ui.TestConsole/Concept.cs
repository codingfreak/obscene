// ReSharper disable InconsistentNaming
namespace codingfreaks.obscene.Ui.TestConsole
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Performs a simple circle drawing.
    /// </summary>
    internal static class Concept
    {
        #region constants

        private const byte AC_SRC_ALPHA = 0x01;
        private const byte AC_SRC_OVER = 0x00;
        private const byte CircleAlpha = 128; // 0=invisible, 255=opaque (128 ≈ 50%)

        private const int CircleSize = 200; // diameter in pixels
        private const int ScreenX = 100; // screen position, top-left of bounding box
        private const int ScreenY = 100;
        private const uint ULW_ALPHA = 0x02;

        private const uint WM_DESTROY = 0x0002;

        private const int WS_EX_LAYERED = 0x00080000;
        private const int WS_EX_TOOLWINDOW = 0x00000080; // hide from taskbar/Alt-Tab
        private const int WS_EX_TOPMOST = 0x00000008; // always on top
        private const int WS_EX_TRANSPARENT = 0x00000020; // click-through
        private const int WS_POPUP = unchecked((int)0x80000000);

        private static readonly WndProcDelegate s_wndProc = WndProc;

        #endregion

        #region methods

        // ─── Entry point ───────────────────────────────────────────────────────────[
        public static void Demo(Action drawCallback)
        {
            var hInstance = GetModuleHandleW(IntPtr.Zero);
            var classNameZ = Marshal.StringToHGlobalUni("RedCircleOverlay");
            try
            {
                var wc = new WNDCLASSEX
                {
                    cbSize = (uint)Marshal.SizeOf<WNDCLASSEX>(),
                    lpfnWndProc = Marshal.GetFunctionPointerForDelegate(s_wndProc),
                    hInstance = hInstance,
                    lpszClassName = classNameZ
                };
                RegisterClassEx(ref wc);
                var hWnd = CreateWindowEx(
                    WS_EX_LAYERED | WS_EX_TRANSPARENT | WS_EX_TOPMOST | WS_EX_TOOLWINDOW,
                    "RedCircleOverlay",
                    string.Empty,
                    WS_POPUP,
                    ScreenX,
                    ScreenY,
                    CircleSize,
                    CircleSize,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    hInstance,
                    IntPtr.Zero);
                if (hWnd == IntPtr.Zero)
                {
                    Console.Error.WriteLine($"CreateWindowEx failed (error {Marshal.GetLastPInvokeError()})");
                    return;
                }
                DrawCircle(hWnd);
                ShowWindow(hWnd, 1 /* SW_SHOWNORMAL */);
                drawCallback.Invoke();
            }
            finally
            {
                Marshal.FreeHGlobal(classNameZ);
            }
        }

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("user32.dll", EntryPoint = "CreateWindowExW", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateWindowEx(
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
        private static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll", EntryPoint = "DispatchMessageW", ExactSpelling = true)]
        private static extern IntPtr DispatchMessage(ref MSG lpMsg);

        // ─── Circle rendering ──────────────────────────────────────────────────────
        private static void DrawCircle(IntPtr hWnd)
        {
            int w = CircleSize, h = CircleSize;
            using var bmp = new Bitmap(w, h, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(Color.FromArgb(CircleAlpha, 220, 20, 20));
                g.FillEllipse(brush, 0, 0, w - 1, h - 1);
                using var pen = new Pen(Color.FromArgb(CircleAlpha / 2, 120, 0, 0), 2f);
                g.DrawEllipse(pen, 1, 1, w - 3, h - 3);
            }
            var screenDc = GetDC(IntPtr.Zero);
            var memDc = CreateCompatibleDC(screenDc);
            var hBitmap = IntPtr.Zero;
            var oldBitmap = IntPtr.Zero;
            try
            {
                hBitmap = bmp.GetHbitmap(Color.FromArgb(0));
                oldBitmap = SelectObject(memDc, hBitmap);
                var size = new SIZE
                {
                    cx = w,
                    cy = h
                };
                var ptSrc = new POINT
                {
                    x = 0,
                    y = 0
                };
                var ptDst = new POINT
                {
                    x = ScreenX,
                    y = ScreenY
                };
                var blend = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255, // per-pixel alpha drives transparency
                    AlphaFormat = AC_SRC_ALPHA
                };
                UpdateLayeredWindow(hWnd, screenDc, ref ptDst, ref size, memDc, ref ptSrc, 0, ref blend, ULW_ALPHA);
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    SelectObject(memDc, oldBitmap);
                    DeleteObject(hBitmap);
                }
                DeleteDC(memDc);
            }
        }

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern IntPtr GetDC(IntPtr hwnd);

        // ─── Win32 P/Invoke ────────────────────────────────────────────────────────
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetModuleHandleW(IntPtr lpModuleName);

        [DllImport("user32.dll", EntryPoint = "PeekMessageW", ExactSpelling = true)]
        private static extern bool PeekMessage(
            ref MSG lpMsg,
            IntPtr hWnd,
            uint wMsgFilterMin,
            uint wMsgFilterMax,
            uint wRemoveMsg);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll", EntryPoint = "RegisterClassExW", ExactSpelling = true)]
        private static extern ushort RegisterClassEx(ref WNDCLASSEX lpwcx);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern bool TranslateMessage(ref MSG lpMsg);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool UpdateLayeredWindow(
            IntPtr hwnd,
            IntPtr hdcDst,
            ref POINT pptDst,
            ref SIZE psize,
            IntPtr hdcSrc,
            ref POINT pptSrc,
            uint crKey,
            ref BLENDFUNCTION pblend,
            uint dwFlags);

        private static IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg == WM_DESTROY)
            {
                PostQuitMessage(0);
            }
            return DefWindowProc(hWnd, msg, wParam, lParam);
        }

        #endregion

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x, y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE
        {
            public int cx, cy;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WNDCLASSEX
        {
            public uint cbSize;
            public uint style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public IntPtr lpszMenuName;
            public IntPtr lpszClassName;
            public IntPtr hIconSm;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public POINT pt;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}