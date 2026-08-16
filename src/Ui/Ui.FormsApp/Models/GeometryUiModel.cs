namespace codingfreaks.obscene.Ui.FormsApp.Models
{
    using System.ComponentModel;
    using System.Drawing.Design;

    using Editors;

    using Logic.Abstracts.Enumerations;
    using Logic.Abstracts.Interfaces;

    /// <summary>
    /// Is used as the information about a single geometry when bound to an editor.
    /// </summary>
    public class GeometryUiModel
    {
        #region properties

        [Editor(typeof(AlphaColorUiTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Color? BorderColor { get; set; }

        public int? BorderWidth { get; set; }

        [Editor(typeof(AlphaColorUiTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Color FillColor { get; set; }

        public GeometryType GeometryType { get; set; }

        public Point Position { get; set; }

        public Size Size { get; set; }

        public static GeometryUiModel From(object original)
        {
            if (!(original is IGeometry originalGeo))
            {
                throw new ArgumentException("Original type was not IGeometry.", nameof(originalGeo));
            }
            return new GeometryUiModel
            {
                BorderColor = originalGeo.BorderColor,
                BorderWidth = originalGeo.BorderWidth,
                FillColor = originalGeo.FillColor,
                GeometryType = originalGeo.GeometryType,
                Position = originalGeo.Position,
                Size = originalGeo.Size
            };
        }

        #endregion
    }
}
