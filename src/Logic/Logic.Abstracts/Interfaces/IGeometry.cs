namespace codingfreaks.obscene.Logic.Abstracts.Interfaces
{
    using System.Drawing;

    /// <summary>
    /// Must be implemented by all types which represent forms drawn to the screen.
    /// </summary>
    public interface IGeometry
    {
        #region methods

        /// <summary>
        /// Draws the form to the screen or refreshes it.
        /// </summary>
        void Draw();

        /// <summary>
        /// Gets or sets the absolute position on the screen.
        /// </summary>
        Point Position { get; set; }

        #endregion
    }
}