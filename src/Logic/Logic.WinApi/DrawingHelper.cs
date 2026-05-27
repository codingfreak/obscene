// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToUsingDeclaration

namespace codingfreaks.obscene.Logic.WinApi
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    using ApiTypes;

    using Models;

    /// <summary>
    /// Provides helper methods to draw stuff using the Windows API.
    /// </summary>
    public static class DrawingHelper
    {
        #region methods

        /// <summary>
        /// Cleansup a drawn window using the provided <paramref name="info" />.
        /// </summary>
        /// <param name="info">The information retrieved by an drawing method.</param>
        public static void CleanupWindow(GeometryInformation info)
        {
            WinApiHelper.ReleaseDC(IntPtr.Zero, info.ScreenDeviceContext);
            if (info.Bitmap != IntPtr.Zero)
            {
                WinApiHelper.SelectObject(info.MemoryDeviceContext, info.OldBitmap);
                WinApiHelper.DeleteObject(info.Bitmap);
            }
            WinApiHelper.DeleteDC(info.MemoryDeviceContext);
        }

        /// <summary>
        /// Draws a circle using the given information to the screen.
        /// </summary>
        /// <remarks>
        /// Use <see cref="InitializeWindow" /> in order to retrieve the <see cref="handle" />!
        /// </remarks>
        /// <param name="handle">The handle of the created window.</param>
        /// <param name="position">The absolute position on the screen.</param>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="fillColor">The color to fill the circle with.</param>
        /// <param name="transparency">The transparency of the fill area.</param>
        /// <param name="strokeColor">Optional color for a stroke.</param>
        /// <returns>The informaiton to later move or maybe cleanup the geometry.</returns>
        public static GeometryInformation DrawCircle(
            IntPtr handle,
            Point position,
            int radius,
            Color fillColor,
            Color? strokeColor = null,
            float? strokeWidth = 2)
        {
            using (var bmp = new Bitmap(position.X, position.Y, PixelFormat.Format32bppArgb))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var brush = new SolidBrush(fillColor))
                    {
                        g.FillEllipse(brush, 0, 0, radius - 1, radius - 1);
                        if (strokeColor != null && strokeWidth != null)
                        {
                            using (var pen = new Pen(strokeColor.Value, strokeWidth.Value))
                            {
                                g.DrawEllipse(
                                    pen,
                                    1,
                                    1,
                                    radius - (strokeWidth.Value + 1),
                                    radius - (strokeWidth.Value + 1));
                            }
                        }
                    }
                }
                var screenDc = WinApiHelper.GetDC(IntPtr.Zero);
                var memDc = WinApiHelper.CreateCompatibleDC(screenDc);
                var hBitmap = IntPtr.Zero;
                var oldBitmap = IntPtr.Zero;
                hBitmap = bmp.GetHbitmap(Color.FromArgb(0));
                oldBitmap = WinApiHelper.SelectObject(memDc, hBitmap);
                var size = new SIZE
                {
                    cx = radius,
                    cy = radius
                };
                var ptSrc = new POINT
                {
                    x = 0,
                    y = 0
                };
                var ptDst = new POINT
                {
                    x = position.X,
                    y = position.Y
                };
                var blend = new BLENDFUNCTION
                {
                    BlendOp = WinApiConstants.AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255, // per-pixel alpha drives transparency
                    AlphaFormat = WinApiConstants.AC_SRC_ALPHA
                };
                WinApiHelper.UpdateLayeredWindow(
                    handle,
                    screenDc,
                    ref ptDst,
                    ref size,
                    memDc,
                    ref ptSrc,
                    0,
                    ref blend,
                    WinApiConstants.ULW_ALPHA);
                ShowWindow(handle);
                return new GeometryInformation(handle, screenDc, memDc, hBitmap, oldBitmap);
            }
        }

        /// <summary>
        /// Needs to be called in order to retrieve a valid drawing context for any geometry.
        /// </summary>
        /// <param name="position">The position on the screen.</param>
        /// <param name="size">The size of the window.</param>
        /// <param name="identifier">Optional identifier for the window registration. (GUID is generated if this is omitted).</param>
        /// <returns>The information later needed.</returns>
        /// <exception cref="InvalidOperationException">Is thrown if no window class could be registered.</exception>
        public static WindowInformation InitializeWindow(Point position, Size size, string? identifier = null)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                // lets generate a unique id
                identifier = Guid.NewGuid()
                    .ToString();
            }
            var moduleHandle = WinApiHelper.GetModuleHandleW(IntPtr.Zero);
            var className = Marshal.StringToHGlobalUni(identifier);
            var windowContext = new WNDCLASSEX
            {
                cbSize = (uint)Marshal.SizeOf<WNDCLASSEX>(),
                lpfnWndProc = Marshal.GetFunctionPointerForDelegate(WinApiConstants.s_wndProc),
                hInstance = moduleHandle,
                lpszClassName = className
            };
            WinApiHelper.RegisterClassEx(ref windowContext);
            var handle = WinApiHelper.CreateWindowEx(
                WinApiConstants.WS_EX_LAYERED | WinApiConstants.WS_EX_TRANSPARENT | WinApiConstants.WS_EX_TOPMOST
                | WinApiConstants.WS_EX_TOOLWINDOW,
                identifier,
                string.Empty,
                WinApiConstants.WS_POPUP,
                position.X,
                position.Y,
                size.Width,
                size.Height,
                IntPtr.Zero,
                IntPtr.Zero,
                moduleHandle,
                IntPtr.Zero);
            if (handle == IntPtr.Zero)
            {
                throw new InvalidOperationException($"CreateWindowEx failed (error {Marshal.GetLastPInvokeError()})");
            }
            return new WindowInformation(handle, className, identifier);
        }

        /// <summary>
        /// Ensures that a window with a given <paramref name="handle" /> is shown.
        /// </summary>
        /// <param name="handle">The handle of the created window.</param>
        public static void ShowWindow(IntPtr handle)
        {
            WinApiHelper.ShowWindow(handle, 1 /* SW_SHOWNORMAL */);
        }

        #endregion
    }
}
