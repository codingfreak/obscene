namespace codingfreaks.obscene.Logic.Core.Geometries
{
    using System.Drawing;

    using BaseTypes;

    using WinApi;
    using WinApi.Models;

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
            return DrawingHelper.DrawCircle(Handle.Value, Position, Size.Width, Color.Red, 50, Color.DarkRed);
        }

        #endregion
    }
}