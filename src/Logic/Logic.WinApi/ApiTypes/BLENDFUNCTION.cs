namespace codingfreaks.obscene.Logic.WinApi.ApiTypes
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Controls blending by specifying the blending functions for source and destination bitmaps
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // ReSharper disable once InconsistentNaming
    public struct BLENDFUNCTION
    {
        /// <summary>
        /// The source blend operation. Currently, the only source and destination blend operation that has been defined is
        /// AC_SRC_OVER. For details, see the following Remarks section.
        /// </summary>
        public byte BlendOp;

        /// <summary>
        /// Must be zero.
        /// </summary>
        public byte BlendFlags;

        /// <summary>
        /// Specifies an alpha transparency value to be used on the entire source bitmap. The SourceConstantAlpha value is combined
        /// with any per-pixel alpha values in the source bitmap. If you set SourceConstantAlpha to 0, it is assumed that your
        /// image is transparent. Set the SourceConstantAlpha value to 255 (opaque) when you only want to use per-pixel alpha
        /// values.
        /// </summary>
        public byte SourceConstantAlpha;

        /// <summary>
        /// This member controls the way the source and destination bitmaps are interpreted. AlphaFormat has the following value.
        /// </summary>
        public byte AlphaFormat;
    }
}
