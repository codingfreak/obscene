namespace codingfreaks.obscene.Logic.WinApi.Models
{
    /// <summary>
    /// Transports pointers which are generated during drawing of forms with Win API in order to be able to later pass those
    /// pointers for cleanup or redrawing.
    /// </summary>
    /// <remarks>
    /// This type is immutable.
    /// </remarks>
    public class GeometryInformation
    {
        #region constructors and destructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="handle">The handle to the window instance.</param>
        /// <param name="screenDeviceContext">The handle to the screen device.</param>
        /// <param name="memoryDeviceContext">The handle to the memory.</param>
        /// <param name="bitmap">The handle to access the bitmap.</param>
        /// <param name="oldBitmap">The handle to access the stored old bitmap.</param>
        public GeometryInformation(
            IntPtr handle,
            IntPtr screenDeviceContext,
            IntPtr memoryDeviceContext,
            IntPtr bitmap,
            IntPtr oldBitmap)
        {
            Handle = handle;
            ScreenDeviceContext = screenDeviceContext;
            MemoryDeviceContext = memoryDeviceContext;
            Bitmap = bitmap;
            OldBitmap = oldBitmap;
        }

        #endregion

        #region properties

        /// <summary>
        /// The handle to the window instance.
        /// </summary>
        public IntPtr Handle { get; }

        /// <summary>
        /// The handle to the screen device.
        /// </summary>
        public IntPtr ScreenDeviceContext { get; }

        /// <summary>
        /// The handle to the memory.
        /// </summary>
        public IntPtr MemoryDeviceContext { get; }

        /// <summary>
        /// The handle to access the bitmap.
        /// </summary>
        public IntPtr Bitmap { get; }

        /// <summary>
        /// The handle to access the stored old bitmap.
        /// </summary>
        public IntPtr OldBitmap { get; }

        #endregion
    }
}
