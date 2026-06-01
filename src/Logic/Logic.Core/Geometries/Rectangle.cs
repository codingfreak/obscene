namespace codingfreaks.obscene.Logic.Core.Geometries
{
    using Abstracts.Enumerations;

    using BaseTypes;

    /// <summary>
    /// Provides logic to draw a top-most rectangle on the screen.
    /// </summary>
    public class Rectangle : BaseGeometry
    {
        #region properties

        /// <inheritdoc />
        public override GeometryType GeometryType => GeometryType.Rectangle;

        #endregion
    }
}
