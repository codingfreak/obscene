namespace codingfreaks.obscene.Logic.Core.Geometries
{
    using System.Drawing;

    using Extensions;

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

        /// <inheritdoc />
        protected override object CloneInternal()
        {
            return new Circle
            {
                Id = Id,
                Position = new Point
                {
                    X = Position.X,
                    Y = Position.Y
                },
                Size = new Size
                {
                    Width = Size.Width,
                    Height = Size.Height
                },
                FillColor = FillColor.CreateCopy(),
                BorderColor = BorderColor.CreateCopy(),
                BorderWidth = BorderWidth
            };
        }

        #endregion
    }
}
