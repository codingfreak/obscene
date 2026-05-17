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

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        #endregion
    }
}