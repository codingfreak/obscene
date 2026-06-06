namespace codingfreaks.obscene.Logic.WinApi
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides access to delegates.
    /// </summary>
    /// <remarks>
    /// Usually in Win32 this is representing pointers.
    /// </remarks>
    public static class Delegates
    {
        #region delegates

        /// <summary>
        /// A callback function, which you define in your application, that processes messages sent to a window. The WNDPROC type
        /// defines a pointer to this callback function. The WndProc name is a placeholder for the name of the function that you
        /// define in your application.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="msg">The message.</param>
        /// <param name="wParam">Additional message information. </param>
        /// <param name="lParam">Additional message information.</param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        #endregion
    }
}
