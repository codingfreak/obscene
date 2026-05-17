namespace codingfreaks.obscene.Logic.Abstracts.Interfaces
{
    using System.Drawing;

    /// <summary>
    /// Must be implemented by all types which represent forms drawn to the screen.
    /// </summary>
    public interface IGeometry : IDisposable
    {
        #region methods

        /// <summary>
        /// Draws the geometry to the screen or refreshes it.
        /// </summary>
        void Draw();

        /// <summary>
        /// Redraws the geometry if needed.
        /// </summary>
        void Refresh();

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the absolute position on the screen.
        /// </summary>
        Point Position { get; set; }

        /// <summary>
        /// Gets or sets the size on the screen.
        /// </summary>
        Size Size { get; set; }

        /// <summary>
        /// The fill color to use.
        /// </summary>
        Color FillColor { get; set; }

        /// <summary>
        /// The optional border color to use.
        /// </summary>
        Color? BorderColor { get; set; }

        /// <summary>
        /// The optional width of the border.
        /// </summary>
        int? BorderWidth { get; set; }

        #endregion
    }
}