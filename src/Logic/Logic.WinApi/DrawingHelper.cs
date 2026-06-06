namespace codingfreaks.obscene.Logic.WinApi
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    using Abstracts.Enumerations;

    using ApiTypes;

    using Models;

    /// <summary>
    /// Provides helper methods to draw stuff using the Windows API.
    /// </summary>
    public static class DrawingHelper
    {
        #region methods

        /// <summary>
        /// Cleansup a drawn window using the provided <paramref Name="info" />.
        /// </summary>
        /// <param name="info">The information retrieved by an drawing method.</param>
        public static void CleanupWindow(GeometryInformation info)
        {
            WinApiHelper.DestroyWindow(info.Handle);
            WinApiHelper.ReleaseDC(IntPtr.Zero, info.ScreenDeviceContext);
            if (info.Bitmap != IntPtr.Zero)
            {
                WinApiHelper.SelectObject(info.MemoryDeviceContext, info.OldBitmap);
                WinApiHelper.DeleteObject(info.Bitmap);
            }
            WinApiHelper.DeleteDC(info.MemoryDeviceContext);
        }

        /// <summary>
        /// Draws a ellipse using the given information to the screen.
        /// </summary>
        /// <remarks>
        /// Use <see cref="InitializeWindow" /> in order to retrieve the <see cref="handle" />!
        /// </remarks>
        /// <param name="handle">The handle of the created window.</param>
        /// <param name="position">The absolute position on the screen.</param>
        /// <param name="size">The size of the rectangle.</param>
        /// <param name="fillColor">The color to fill the circle with.</param>
        /// <param name="strokeColor">Optional color for a stroke.</param>
        /// <param name="strokeWidth">The width of the outline stroke.</param>
        /// <returns>The information to later move or maybe cleanup the geometry.</returns>
        public static GeometryInformation DrawEllipse(
            IntPtr handle,
            Point position,
            Size size,
            Color fillColor,
            Color? strokeColor = null,
            float? strokeWidth = 2)
        {
            return DrawWindow(GeometryType.Ellipse, handle, position, size, fillColor, strokeColor, strokeWidth);
        }

        /// <summary>
        /// Draws a rectangle using the given information to the screen.
        /// </summary>
        /// <remarks>
        /// Use <see cref="InitializeWindow" /> in order to retrieve the <see cref="handle" />!
        /// </remarks>
        /// <param name="handle">The handle of the created window.</param>
        /// <param name="position">The absolute position on the screen.</param>
        /// <param name="size">The size of the rectangle.</param>
        /// <param name="fillColor">The color to fill the circle with.</param>
        /// <param name="strokeColor">Optional color for a stroke.</param>
        /// <param name="strokeWidth">The width of the outline stroke.</param>
        /// <returns>The information to later move or maybe cleanup the geometry.</returns>
        public static GeometryInformation DrawRectangle(
            IntPtr handle,
            Point position,
            Size size,
            Color fillColor,
            Color? strokeColor = null,
            float? strokeWidth = 2)
        {
            return DrawWindow(GeometryType.Rectangle, handle, position, size, fillColor, strokeColor, strokeWidth);
        }

        /// <summary>
        /// Draws a window to the screen based on the information passed.
        /// </summary>
        /// <remarks>
        /// Use <see cref="InitializeWindow" /> in order to retrieve the <see cref="handle" />!
        /// </remarks>
        /// <param name="type">The geometry type to draw the window for.</param>
        /// <param name="handle">The handle of the created window.</param>
        /// <param name="position">The absolute position on the screen.</param>
        /// <param name="size">The size of the ellipse.</param>
        /// <param name="fillColor">The color to fill the circle with.</param>
        /// <param name="strokeColor">Optional color for a stroke.</param>
        /// <param name="strokeWidth">The width of the outline stroke.</param>
        /// <returns>The information to later move or maybe cleanup the geometry.</returns>
        public static GeometryInformation DrawWindow(
            GeometryType type,
            IntPtr handle,
            Point position,
            Size size,
            Color fillColor,
            Color? strokeColor = null,
            float? strokeWidth = 2)
        {
            if (type == GeometryType.Undefined)
            {
                throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(GeometryType));
            }
            using (var bmp = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Transparent);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var brush = new SolidBrush(fillColor))
                    {
                        switch (type)
                        {
                            case GeometryType.Rectangle:
                                g.FillRectangle(brush, 0, 0, size.Width - 1, size.Height - 1);
                                break;
                            case GeometryType.Ellipse:
                                g.FillEllipse(brush, 0, 0, size.Width - 1, size.Height - 1);
                                break;
                        }
                        if (strokeColor != null && strokeWidth != null)
                        {
                            using (var pen = new Pen(strokeColor.Value, strokeWidth.Value))
                            {
                                switch (type)
                                {
                                    case GeometryType.Rectangle:
                                        g.DrawRectangle(
                                            pen,
                                            1,
                                            1,
                                            size.Width - (strokeWidth.Value + 1),
                                            size.Height - (strokeWidth.Value + 1));
                                        break;
                                    case GeometryType.Ellipse:
                                        g.DrawEllipse(
                                            pen,
                                            1,
                                            1,
                                            size.Width - (strokeWidth.Value + 1),
                                            size.Height - (strokeWidth.Value + 1));
                                        break;
                                }
                            }
                        }
                    }
                }
                var screenDc = WinApiHelper.GetDC(IntPtr.Zero);
                var memDc = WinApiHelper.CreateCompatibleDC(screenDc);
                var hBitmap = bmp.GetHbitmap(Color.FromArgb(0));
                var oldBitmap = WinApiHelper.SelectObject(memDc, hBitmap);
                var ptSize = new SIZE
                {
                    cx = size.Width,
                    cy = size.Height
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
                    ref ptSize,
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
        /// Is used to redraw a window.
        /// </summary>
        /// <param name="type">The geometry type to draw the</param>
        /// <param name="geo">The geometry information.</param>
        /// <param name="newPosition">The new position.</param>
        /// <param name="newSize">The new size.</param>
        /// <param name="fillColor">The fill color to use.</param>
        /// <param name="strokeColor">Optional stroke color to use.</param>
        /// <param name="strokeWidth">Optional width of the stroke in px.</param>
        public static GeometryInformation MoveAndResizeGeometry(
            GeometryType type,
            GeometryInformation geo,
            Point newPosition,
            Size newSize,
            Color fillColor,
            Color? strokeColor = null,
            float? strokeWidth = 2)
        {
            // 1. Move and resize the window frame
            WinApiHelper.SetWindowPos(
                geo.Handle,
                IntPtr.Zero,
                newPosition.X,
                newPosition.Y,
                newSize.Width,
                newSize.Height,
                WinApiConstants.SWP_NOZORDER | WinApiConstants.SWP_NOACTIVATE);
            // 2. Clean up the old GDI objects before creating new ones
            WinApiHelper.SelectObject(geo.MemoryDeviceContext, geo.OldBitmap);
            WinApiHelper.DeleteObject(geo.Bitmap);
            WinApiHelper.DeleteDC(geo.MemoryDeviceContext);
            WinApiHelper.ReleaseDC(IntPtr.Zero, geo.ScreenDeviceContext);
            // 3. Redraw into a new bitmap at the new size
            using var bmp = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(fillColor))
                {
                    switch (type)
                    {
                        case GeometryType.Rectangle:
                            g.FillRectangle(brush, 0, 0, newSize.Width, newSize.Height);
                            break;
                        case GeometryType.Ellipse:
                            g.FillEllipse(brush, 0, 0, newSize.Width, newSize.Height);
                            break;
                    }
                    if (strokeColor != null && strokeWidth != null)
                    {
                        using (var pen = new Pen(strokeColor.Value, strokeWidth.Value))
                        {
                            switch (type)
                            {
                                case GeometryType.Rectangle:
                                    g.DrawRectangle(
                                        pen,
                                        1,
                                        1,
                                        newSize.Width - (strokeWidth.Value + 1),
                                        newSize.Height - (strokeWidth.Value + 1));
                                    break;
                                case GeometryType.Ellipse:
                                    g.DrawEllipse(
                                        pen,
                                        1,
                                        1,
                                        newSize.Width - (strokeWidth.Value + 1),
                                        newSize.Height - (strokeWidth.Value + 1));
                                    break;
                            }
                        }
                    }
                }
            }
            // re-calc the values
            var screenDc = WinApiHelper.GetDC(IntPtr.Zero);
            var memDc = WinApiHelper.CreateCompatibleDC(screenDc);
            var hBitmap = bmp.GetHbitmap(Color.FromArgb(0));
            var oldBitmap = WinApiHelper.SelectObject(memDc, hBitmap);
            var ptDst = new POINT
            {
                x = newPosition.X,
                y = newPosition.Y
            };
            var ptSrc = new POINT
            {
                x = 0,
                y = 0
            };
            var size = new SIZE
            {
                cx = newSize.Width,
                cy = newSize.Height
            };
            var blend = new BLENDFUNCTION
            {
                BlendOp = WinApiConstants.AC_SRC_OVER,
                BlendFlags = 0,
                SourceConstantAlpha = 255,
                AlphaFormat = WinApiConstants.AC_SRC_ALPHA
            };
            // 4. Push the new surface via UpdateLayeredWindow
            WinApiHelper.UpdateLayeredWindow(
                geo.Handle,
                screenDc,
                ref ptDst,
                ref size,
                memDc,
                ref ptSrc,
                0,
                ref blend,
                WinApiConstants.ULW_ALPHA);
            return new GeometryInformation(geo.Handle, screenDc, memDc, hBitmap, oldBitmap);
        }

        /// <summary>
        /// Ensures that a window with a given <paramref Name="handle" /> is shown.
        /// </summary>
        /// <param name="handle">The handle of the created window.</param>
        public static void ShowWindow(IntPtr handle)
        {
            WinApiHelper.ShowWindow(handle, WinApiConstants.SW_SHOWNORMAL);
        }

        #endregion
    }
}
