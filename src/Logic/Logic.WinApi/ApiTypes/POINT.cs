namespace codingfreaks.obscene.Logic.WinApi.ApiTypes
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the x- and y-coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct POINT
    {
        /// <summary>
        /// Specifies the x-coordinate of the point.
        /// </summary>
        public int x;

        /// <summary>
        /// Specifies the y-coordinate of the point.
        /// </summary>
        public int y;
    }
}
