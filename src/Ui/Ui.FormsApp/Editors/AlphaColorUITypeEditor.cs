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
            using (var picker = new Controls.AlphaColorPicker(value as Color?, nullable, svc))
            {
                svc.DropDownControl(picker);
                return nullable && picker.IsNull ? null : picker.SelectedColor;
            }
        }

        /// <inheritdoc />
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
            var graphics = e.Graphics;
            var bounds = e.Bounds;
            // opaque checkerboard so alpha is actually visible
            const int Cell = 4;
            using (var lightBrush = new SolidBrush(Color.White))
            {
                using (var darkBrush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillRectangle(lightBrush, bounds);
                    for (var y = 0; y < bounds.Height; y += Cell)
                    {
                        for (var x = 0; x < bounds.Width; x += Cell)
                        {
                            if ((x / Cell + y / Cell) % 2 == 0)
                            {
                                graphics.FillRectangle(
                                    darkBrush,
                                    bounds.X + x,
                                    bounds.Y + y,
                                    Math.Min(Cell, bounds.Width - x),
                                    Math.Min(Cell, bounds.Height - y));
                            }
                        }
                    }
                    using (var fill = new SolidBrush(color))
                    {
                        graphics.FillRectangle(fill, bounds);
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
