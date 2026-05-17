namespace codingfreaks.obscene.Logic.Core.Geometries
{
    using System.Drawing;

    using BaseTypes;

    using WinApi;
    using WinApi.Models;

    /// <summary>
    /// Provides logic to draw a top-most cirle on the screen.
    /// </summary>
    public class Circle : BaseGeometry
    {
        #region methods

        /// <inheritdoc />
        protected override GeometryInformation InitGeometry()
        {
            if (Handle == null)
            {
                throw new InvalidOperationException("No handle was present.");
            }
            return DrawingHelper.DrawCircle(Handle.Value, Position, Size.Width, FillColor, BorderColor);
        }

        /// <inheritdoc />
        protected override bool BeforeSizeChange(ref Size value)
        {
            value.Height = value.Width;
            return base.BeforeSizeChange(ref value);
        }

        #endregion
    }
}