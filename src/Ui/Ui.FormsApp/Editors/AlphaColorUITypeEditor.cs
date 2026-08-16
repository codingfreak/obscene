namespace codingfreaks.obscene.Ui.FormsApp.Editors
{
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms.Design;

    /// <summary>
    /// Custom editor for a color used in a property grid.
    /// </summary>
    public class AlphaColorUiTypeEditor : UITypeEditor
    {
        #region methods

        /// <inheritdoc />
        public override object? EditValue(ITypeDescriptorContext? context, IServiceProvider provider, object? value)
        {
            if (provider?.GetService(typeof(IWindowsFormsEditorService)) is not IWindowsFormsEditorService svc)
            {
                return value;
            }
            var nullable = context?.PropertyDescriptor?.PropertyType == typeof(Color?);
            using (var picker = new AlphaColorPicker(value as Color?, nullable, svc))
            {
                svc.DropDownControl(picker);
                return nullable && picker.IsNull ? null : picker.SelectedColor;
            }
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext? context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        /// <inheritdoc />
        public override bool GetPaintValueSupported(ITypeDescriptorContext? c)
        {
            return true;
        }

        /// <inheritdoc />
        public override void PaintValue(PaintValueEventArgs e)
        {
            if (e.Value is not Color color)
            {
                // null (Color?) => no swatch
                return;
            }
            var g = e.Graphics;
            var b = e.Bounds;
            // opaque checkerboard so alpha is actually visible
            const int Cell = 4;
            using (var light = new SolidBrush(Color.White))
            {
                using (var dark = new SolidBrush(Color.LightGray))
                {
                    g.FillRectangle(light, b);
                    for (var y = 0; y < b.Height; y += Cell)
                    {
                        for (var x = 0; x < b.Width; x += Cell)
                        {
                            if ((x / Cell + y / Cell) % 2 == 0)
                            {
                                g.FillRectangle(
                                    dark,
                                    b.X + x,
                                    b.Y + y,
                                    Math.Min(Cell, b.Width - x),
                                    Math.Min(Cell, b.Height - y));
                            }
                        }
                    }
                    using (var fill = new SolidBrush(color))
                    {
                        g.FillRectangle(fill, b);
                    }
                }
            }
        }

        #endregion

        #region properties

        /// <inheritdoc />
        public override bool IsDropDownResizable => false;

        #endregion
    }
}
