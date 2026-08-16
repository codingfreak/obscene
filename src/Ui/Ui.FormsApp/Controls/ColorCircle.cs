namespace codingfreaks.obscene.Ui.FormsApp.Controls
{
    using Models;

    using System.ComponentModel;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A control which allows the selection of a color from a wheel.
    /// </summary>
    public class ColorCircle : Control
    {
        #region member vars

        private Bitmap? _wheel;

        #endregion

        #region events

        /// <summary>
        /// Occurs when a new color value is selected.
        /// </summary>
        public event EventHandler<ColorClickedEventArgs>? OnColorChanged;

        #endregion

        #region constructors and destructors

        public ColorCircle()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #endregion

        #region methods

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _wheel?.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <inheritdoc />
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (_wheel == null)
            {
                return;
            }
            var x = e.X;
            var y = e.Y;
            if (x < 0 || y < 0 || x >= _wheel.Width || y >= _wheel.Height)
            {
                return;
            }
            var color = _wheel.GetPixel(x, y);
            if (color.A == 0)
            {
                // outside the circle (transparent corner)
                return;
            }
            Color = color;
            OnColorChanged?.Invoke(this, new ColorClickedEventArgs(color));
        }

        /// <inheritdoc />
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = ClientRectangle;
            var size = Math.Min(rect.Width, rect.Height) - 1;
            rect.Width = size;
            rect.Height = size;
            if (rect.Width <= 0)
            {
                base.OnPaint(e);
                return;
            }
            _wheel = CreateWheel(rect.Width + 1, rect.Height + 1);
            using (var brush = new TextureBrush(_wheel))
            {
                brush.TranslateTransform(rect.Left, rect.Top);
                e.Graphics.FillEllipse(brush, rect);
            }
            // highlight current color
            if (Color.A != 0)
            {
                RgbToHsv(Color, out var hue, out var sat, out _);
                var w = rect.Width + 1;
                var h = rect.Height + 1;
                var cx = (w - 1) / 2.0;
                var cy = (h - 1) / 2.0;
                var rx = w / 2.0;
                var ry = h / 2.0;
                var a = hue * Math.PI / 180.0;
                var mx = rect.Left + cx + Math.Cos(a) * sat * rx;
                var my = rect.Top + cy + Math.Sin(a) * sat * ry;
                const float R = 6f;
                var marker = new RectangleF((float)(mx - R), (float)(my - R), R * 2, R * 2);
                using (var outer = new Pen(Color.White, 3f))
                {
                    using (var inner = new Pen(Color.Black, 1f))
                    {
                        e.Graphics.DrawEllipse(outer, marker);
                        e.Graphics.DrawEllipse(inner, marker);
                    }
                }
            }
            base.OnPaint(e);
        }

        /// <summary>
        /// Creates a new color wheel bitmap to be drawn on the control.
        /// </summary>
        /// <param name="width">The width of the surrounding rectangle.</param>
        /// <param name="height">The height of the surrounding rectangle.</param>
        /// <returns></returns>
        private static Bitmap CreateWheel(int width, int height)
        {
            var result = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var data = result.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            try
            {
                var buffer = new byte[data.Stride * height];
                var cx = (width - 1) / 2.0;
                var cy = (height - 1) / 2.0;
                var rx = width / 2.0;
                var ry = height / 2.0;
                for (var y = 0; y < height; y++)
                {
                    var rowStart = y * data.Stride;
                    for (var x = 0; x < width; x++)
                    {
                        var dx = (x - cx) / rx;
                        var dy = (y - cy) / ry;
                        var dist = Math.Sqrt(dx * dx + dy * dy);
                        var hue = Math.Atan2(dy, dx) * 180.0 / Math.PI;
                        if (hue < 0)
                        {
                            hue += 360;
                        }
                        HsvToRgb(hue, Math.Min(dist, 1.0), 1.0, out var r, out var g, out var b);
                        var p = rowStart + x * 4;
                        buffer[p + 0] = b; // BGRA
                        buffer[p + 1] = g;
                        buffer[p + 2] = r;
                        buffer[p + 3] = 255;
                    }
                }
                Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
            }
            finally
            {
                result.UnlockBits(data);
            }
            return result;
        }

        /// <summary>
        /// Converts HSV to RGB values.
        /// </summary>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="brightness"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        private static void HsvToRgb(double hue, double saturation, double brightness, out byte red, out byte green, out byte blue)
        {
            var c = brightness * saturation;
            var x = c * (1 - Math.Abs(hue / 60.0 % 2 - 1));
            var m = brightness - c;
            double rd, gd, bd;
            switch ((int)(hue / 60) % 6)
            {
                case 0:
                    rd = c;
                    gd = x;
                    bd = 0;
                    break;
                case 1:
                    rd = x;
                    gd = c;
                    bd = 0;
                    break;
                case 2:
                    rd = 0;
                    gd = c;
                    bd = x;
                    break;
                case 3:
                    rd = 0;
                    gd = x;
                    bd = c;
                    break;
                case 4:
                    rd = x;
                    gd = 0;
                    bd = c;
                    break;
                default:
                    rd = c;
                    gd = 0;
                    bd = x;
                    break;
            }
            red = (byte)Math.Round((rd + m) * 255);
            green = (byte)Math.Round((gd + m) * 255);
            blue = (byte)Math.Round((bd + m) * 255);
        }

        private static void RgbToHsv(Color c, out double h, out double s, out double v)
        {
            var r = c.R / 255.0;
            var g = c.G / 255.0;
            var b = c.B / 255.0;
            var max = Math.Max(r, Math.Max(g, b));
            var min = Math.Min(r, Math.Min(g, b));
            var delta = max - min;
            v = max;
            s = max == 0 ? 0 : delta / max;
            if (delta == 0)
            {
                h = 0;
            }
            else if (max == r)
            {
                h = 60 * ((g - b) / delta % 6);
            }
            else if (max == g)
            {
                h = 60 * ((b - r) / delta + 2);
            }
            else
            {
                h = 60 * ((r - g) / delta + 4);
            }
            if (h < 0)
            {
                h += 360;
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// The currently selected color.
        /// </summary>
        [DefaultValue(typeof(Color), "Empty")]
        public Color Color
        {
            get;
            set
            {
                field = value;
                Refresh();
            }
        } = Color.White;

        #endregion
    }
}
