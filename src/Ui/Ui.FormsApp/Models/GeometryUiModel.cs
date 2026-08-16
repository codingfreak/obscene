namespace codingfreaks.obscene.Ui.FormsApp.Models
{
    using System.ComponentModel;
    using System.Drawing.Design;

    using Editors;

    using Logic.Abstracts.Enumerations;
    using Logic.Abstracts.Interfaces;
    using Logic.Core.Geometries;

    /// <summary>
    /// Is used as the information about a single geometry when bound to an editor.
    /// </summary>
    public class GeometryUiModel
    {
        #region methods

        public void ApplyTo(IGeometry geometry)
        {
            geometry.Id = Id;
            geometry.BorderColor = BorderColor;
            geometry.BorderWidth = BorderWidth;
            geometry.FillColor = FillColor;
            geometry.Position = Position;
            geometry.Size = Size;
        }

        public static GeometryUiModel From(object original)
        {
            if (!(original is IGeometry originalGeo))
            {
                throw new ArgumentException("Original type was not IGeometry.", nameof(originalGeo));
            }
            return new GeometryUiModel
            {
                Id = originalGeo.Id,
                BorderColor = originalGeo.BorderColor,
                BorderWidth = originalGeo.BorderWidth,
                FillColor = originalGeo.FillColor,
                GeometryType = originalGeo.GeometryType,
                Position = originalGeo.Position,
                Size = originalGeo.Size
            };
        }

        public IGeometry ToGeometry()
        {
            IGeometry result;
            switch (GeometryType)
            {
                case GeometryType.Ellipse:
                    result = Size.Height == Size.Width ? new Circle() : new Ellipse();
                    break;
                case GeometryType.Rectangle:
                    result = new Rectangle();
                    break;
                default:
                    throw new InvalidOperationException("Could not resolve geometry.");
            }
            result.Id = Id;
            result.BorderColor = BorderColor;
            result.BorderWidth = BorderWidth;
            result.FillColor = FillColor;
            result.Position = Position;
            result.Size = Size;
            return result;
        }

        #endregion

        #region properties

        [Editor(typeof(AlphaColorUiTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Color? BorderColor { get; set; }

        public int? BorderWidth { get; set; }

        public string Id { get; set; } = null!;

        [Editor(typeof(AlphaColorUiTypeEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Color FillColor { get; set; }

        public GeometryType GeometryType { get; set; }

        public Point Position { get; set; }

        public Size Size { get; set; }

        #endregion
    }
}
