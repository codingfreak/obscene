namespace codingfreaks.obscene.Logic.Core.Geometries
{
    using Abstracts.Enumerations;

    using BaseTypes;

    using codingfreaks.obscene.Logic.Core.Extensions;

    using System.Drawing;

    /// <summary>
    /// Provides logic to draw a top-most rectangle on the screen.
    /// </summary>
    public class Rectangle : BaseGeometry
    {
        #region methods

        /// <inheritdoc />
        protected override object CloneInternal()
        {
            return new Rectangle
            {
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

        #region properties

        /// <inheritdoc />
        public override GeometryType GeometryType => GeometryType.Rectangle;

        #endregion
    }
}
