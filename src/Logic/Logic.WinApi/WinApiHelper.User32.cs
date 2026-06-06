namespace codingfreaks.obscene.Logic.WinApi
{
    using System.Runtime.InteropServices;

    using ApiTypes;

    internal static partial class WinApiHelper
    {
        #region methods

        /// <summary>
        /// Creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to
        /// the CreateWindow function. For more information about creating a window and for full descriptions of the other
        /// parameters of CreateWindowEx, see CreateWindow.
        /// </summary>
        /// <param name="dwExStyle">The extended window style of the window being created.</param>
        /// <param name="lpClassName">A null-terminated string or a class atom.</param>
        /// <param name="lpWindowName">
        /// The window name. If the window style specifies a title bar, the window title pointed to by
        /// lpWindowName is displayed in the title bar.
        /// </param>
        /// <param name="dwStyle">
        /// The style of the window being created. See
        /// https://learn.microsoft.com/en-us/windows/win32/winmsg/window-styles.
        /// </param>
        /// <param name="x">The initial horizontal position of the window.</param>
        /// <param name="y">he initial vertical position of the window.</param>
        /// <param name="nWidth">The width, in device units, of the window.</param>
        /// <param name="nHeight">The height, in device units, of the window.</param>
        /// <param name="hWndParent">A handle to the parent or owner window of the window being created.</param>
        /// <param name="hMenu">A handle to a menu, or specifies a child-window identifier, depending on the window style.</param>
        /// <param name="hInstance">A handle to the instance of the module to be associated with the window.</param>
        /// <param name="lpParam">
        /// Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams
        /// member) pointed to by the lParam param of the WM_CREATE message. This message is sent to the created window by this
        /// function before it returns.
        /// </param>
        /// <returns>The handle to the created window if succeeded otherwise NULL.</returns>
        [DllImport("user32.dll", EntryPoint = "CreateWindowExW", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateWindowEx(
            int dwExStyle,
            string lpClassName,
            string lpWindowName,
            int dwStyle,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lpParam);

        /// <summary>
        /// Calls the default window procedure to provide default processing for any window messages that an application does not
        /// process.
        /// </summary>
        /// <param name="hWnd">A handle to the window procedure that received the message.</param>
        /// <param name="msg">The message.</param>
        /// <param name="wParam">
        /// Additional message information. The content of this parameter depends on the value of the Msg
        /// parameter.
        /// </param>
        /// <param name="lParam">
        /// Additional message information. The content of this parameter depends on the value of the Msg
        /// parameter.
        /// </param>
        /// <returns>The result of the message processing and depends on the message.</returns>
        [DllImport("user32.dll", EntryPoint = "DefWindowProcW", ExactSpelling = true)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Destroys the specified window.
        /// </summary>
        /// <param name="hWnd">A handle to the window to be destroyed.</param>
        /// <returns>A non-zero value if the method succeeded otherwise 0.</returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int DestroyWindow(IntPtr hWnd);

        /// <summary>
        /// Dispatches a message to a window procedure. It is typically used to dispatch a message retrieved by the GetMessage
        /// function.
        /// </summary>
        /// <param name="lpMsg">A pointer to a structure that contains the message.</param>
        /// <returns>The value returned by the window procedure.</returns>
        [DllImport("user32.dll", EntryPoint = "DispatchMessageW", ExactSpelling = true)]
        public static extern IntPtr DispatchMessage(ref MSG lpMsg);

        /// <summary>
        /// Determines whether a key is up or down at the time the function is called, and whether the key has been pressed since a
        /// previous call to GetAsyncKeyState.
        /// </summary>
        /// <param name="vKey">The virtual-key code.</param>
        /// <returns>The key state.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern short GetAsyncKeyState(int vKey);

        /// <summary>
        /// Retrieves a handle to a device context (DC) for the client area of a specified window or for the entire screen.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC
        /// for the entire screen.
        /// </param>
        /// <returns>A handle to the DC for the specified window's client area if succeeded otherwise NULL.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetDC(IntPtr hwnd);

        /// <summary>
        /// Dispatches incoming nonqueued messages, checks the thread message queue for a posted message, and retrieves the message
        /// (if any exist).
        /// </summary>
        /// <param name="lpMsg">A pointer to an MSG structure that receives message information.</param>
        /// <param name="hWnd">
        /// A handle to the window whose messages are to be retrieved. The window must belong to the current
        /// thread.
        /// </param>
        /// <param name="wMsgFilterMin">The value of the first message in the range of messages to be examined.</param>
        /// <param name="wMsgFilterMax">The value of the last message in the range of messages to be examined. </param>
        /// <param name="wRemoveMsg">
        /// Specifies how messages are to be handled. This parameter can be one or more of the following
        /// values.
        /// </param>
        /// <returns>A non-zero value if the method succeeded otherwise 0.</returns>
        [DllImport("user32.dll", EntryPoint = "PeekMessageW", ExactSpelling = true)]
        public static extern bool PeekMessage(
            ref MSG lpMsg,
            IntPtr hWnd,
            uint wMsgFilterMin,
            uint wMsgFilterMax,
            uint wRemoveMsg);

        /// <summary>
        /// Indicates to the system that a thread has made a request to terminate (quit). It is typically used in response to a
        /// WM_DESTROY message.
        /// </summary>
        /// <param name="nExitCode">The application exit code. </param>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern void PostQuitMessage(int nExitCode);

        /// <summary>
        /// Registers a window class for subsequent use in calls to the CreateWindow or CreateWindowEx function.
        /// </summary>
        /// <param name="lpwcx">
        /// A pointer to a WNDCLASSEX structure. You must fill the structure with the appropriate class
        /// attributes before passing it to the function.
        /// </param>
        /// <returns>A class atom that uniquely identifies the class being registered if succeeded, otherwise 0.</returns>
        [DllImport("user32.dll", EntryPoint = "RegisterClassExW", ExactSpelling = true)]
        public static extern ushort RegisterClassEx(ref WNDCLASSEX lpwcx);

        /// <summary>
        /// Releases a device context (DC), freeing it for use by other applications.
        /// </summary>
        /// <param name="hwnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hdc">A handle to the DC to be released.</param>
        /// <returns>1 of the handle was released otherwise 0.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order. </param>
        /// <param name="x">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="uFlags">
        /// The window sizing and positioning flags. This parameter can be a combination of the following
        /// values.
        /// </param>
        /// <returns>A non-zero value if the function succeeded otherwise 0.</returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int x,
            int y,
            int cx,
            int cy,
            uint uFlags);

        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="nCmdShow">Controls how the window is to be shown.</param>
        /// <returns>0 if the window was previously hidden otherwise non-zero.</returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// Translates virtual-key messages into character messages.
        /// </summary>
        /// <param name="lpMsg">
        /// A pointer to an MSG structure that contains message information retrieved from the calling thread's
        /// message queue by using the GetMessage or PeekMessage function.
        /// </param>
        /// <returns>
        /// If the message is translated (that is, a character message is posted to the thread's message queue), the
        /// return value is nonzero, otherwise 0.
        /// </returns>
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern bool TranslateMessage(ref MSG lpMsg);

        /// <summary>
        /// Updates the position, size, shape, content, and translucency of a layered window.
        /// </summary>
        /// <param name="hwnd">A handle to a layered window. </param>
        /// <param name="hdcDst">A handle to a DC for the screen.</param>
        /// <param name="pptDst">A pointer to a structure that specifies the new screen position of the layered window.</param>
        /// <param name="psize">A pointer to a structure that specifies the new size of the layered window. </param>
        /// <param name="hdcSrc">A handle to a DC for the surface that defines the layered window.</param>
        /// <param name="pptSrc">A pointer to a structure that specifies the location of the layer in the device context.</param>
        /// <param name="crKey">A structure that specifies the color key to be used when composing the layered window. </param>
        /// <param name="pblend">
        /// A pointer to a structure that specifies the transparency value to be used when composing the
        /// layered window.
        /// </param>
        /// <param name="dwFlags">The custom flags.</param>
        /// <returns>If the function succeeds, the return value is nonzero otherwise 0.</returns>
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(
            IntPtr hwnd,
            IntPtr hdcDst,
            ref POINT pptDst,
            ref SIZE psize,
            IntPtr hdcSrc,
            ref POINT pptSrc,
            uint crKey,
            ref BLENDFUNCTION pblend,
            uint dwFlags);

        #endregion
    }
}
