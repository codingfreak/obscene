namespace codingfreaks.obscene.Logic.Abstracts.Models
{
    using System.Drawing;

    using Enumerations;

    /// <summary>
    /// Represents geometry information on (de-)serialization.
    /// </summary>
    public class GeometryData
    {
        #region properties

        /// <summary>
        /// Unique id of the geometry.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// The type of the geometry.
        /// </summary>
        public GeometryType GeometryType { get; set; }

        /// <summary>
        /// Gets or sets the absolute position on the screen.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Gets or sets the size on the screen.
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// The fill color to use.
        /// </summary>
        public ColorData FillColor { get; set; } = null!;

        /// <summary>
        /// The optional border color to use.
        /// </summary>
        public ColorData? BorderColor { get; set; }

        /// <summary>
        /// The optional width of the border.
        /// </summary>
        public int? BorderWidth { get; set; }

        #endregion
    }
}
