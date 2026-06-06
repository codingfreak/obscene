namespace codingfreaks.obscene.Logic.WinApi.ApiTypes
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the width and height of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    public struct SIZE
    {
        /// <summary>
        /// Specifies the rectangle's width. The units depend on which function uses this structure.
        /// </summary>
        public int cx;

        /// <summary>
        /// Specifies the rectangle's height. The units depend on which function uses this structure.
        /// </summary>
        public int cy;
    }
}
