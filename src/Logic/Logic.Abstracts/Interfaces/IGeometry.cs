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

        #endregion
    }
}