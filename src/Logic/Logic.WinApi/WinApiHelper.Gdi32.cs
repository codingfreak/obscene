namespace codingfreaks.obscene.Logic.WinApi
{
    using System.Runtime.InteropServices;

    internal static partial class WinApiHelper
    {
        #region methods

        /// <summary>
        /// Creates a memory device context (DC) compatible with the specified device.
        /// </summary>
        /// <param name="hdc">
        /// handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with
        /// the application's current screen.
        /// </param>
        /// <returns>The handle to a memory DC if succeeded, otherwise NULL.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        /// <summary>
        /// Deletes the specified device context (DC).
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <returns>A non-zero value if the method succeeded otherwise 0.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hdc);

        /// <summary>
        /// Deletes a logical pen, brush, font, bitmap, region, or palette, freeing all system resources associated with the
        /// object.
        /// </summary>
        /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>A non-zero value if the method succeeded otherwise 0.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// Selects an object into the specified device context (DC).
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="hObject">A handle to the object to be selected. </param>
        /// <returns>A handle to the object being replaced if succeeded, otherwise 0.</returns>
        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        #endregion
    }
}
