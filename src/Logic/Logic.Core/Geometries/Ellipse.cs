namespace codingfreaks.obscene.Logic.Core.Geometries
{
    using Abstracts.Enumerations;

    using BaseTypes;

    /// <summary>
    /// Provides logic to draw a top-most ellipse on the screen.
    /// </summary>
    public class Ellipse : BaseGeometry
    {
        #region properties

        /// <inheritdoc />
        public override GeometryType GeometryType => GeometryType.Ellipse;

        #endregion
    }
}
