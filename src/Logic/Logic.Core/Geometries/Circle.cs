namespace codingfreaks.obscene.Logic.Core.Geometries
{
    using System.Drawing;

    /// <summary>
    /// Provides logic to draw a top-most cirle on the screen.
    /// </summary>
    public class Circle : Ellipse
    {
        #region methods

        /// <inheritdoc />
        protected override bool BeforeSizeChange(ref Size value)
        {
            value.Height = value.Width;
            return base.BeforeSizeChange(ref value);
        }

        #endregion
    }
}
