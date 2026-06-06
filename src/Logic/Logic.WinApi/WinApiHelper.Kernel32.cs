namespace codingfreaks.obscene.Logic.WinApi
{
    using System.Runtime.InteropServices;

    internal static partial class WinApiHelper
    {
        #region methods

        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file).</param>
        /// <returns>A handle to the specified module if succeeded otherwise NULL.</returns>
        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GetModuleHandleW(IntPtr lpModuleName);

        #endregion
    }
}
