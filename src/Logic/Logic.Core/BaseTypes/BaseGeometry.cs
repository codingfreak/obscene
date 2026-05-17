namespace codingfreaks.obscene.Logic.Core.BaseTypes
{
    using System.Drawing;

    using Abstracts.Interfaces;

    using WinApi;
    using WinApi.Models;

    /// <summary>
    /// Abstract base type for all drawable geometries.
    /// </summary>
    public abstract class BaseGeometry : IGeometry
    {
        #region member vars

        private bool _isDisposed;

        private WindowInformation? _windowContext;

        #endregion

        #region explicit interfaces

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        public void Draw()
        {
            _windowContext = DrawingHelper.InitializeWindow(Position, Size);
            GeometryInformation = InitGeometry();
        }

        /// <inheritdoc />
        public Point Position
        {
            get;
            set
            {
                if (!BeforePositionChange(value))
                {
                    return;
                }
                field = value;
                Refresh();
            }
        }

        /// <inheritdoc />
        public void Refresh()
        {
        }

        /// <inheritdoc />
        public Size Size
        {
            get;
            set
            {
                if (!BeforeSizeChange(value))
                {
                    return;
                }
                field = value;
                Refresh();
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Can be overridden by children to react before position changes.
        /// </summary>
        /// <param name="value">The new value that should be applied.</param>
        /// <returns><c>true</c> if the value should be accepted, otherwise <c>false</c>.</returns>
        protected virtual bool BeforePositionChange(Point value)
        {
            return true;
        }

        /// <summary>
        /// Can be overridden by children to react before size changes.
        /// </summary>
        /// <param name="value">The new value that should be applied.</param>
        /// <returns><c>true</c> if the value should be accepted, otherwise <c>false</c>.</returns>
        protected virtual bool BeforeSizeChange(Size value)
        {
            return true;
        }

        /// <summary>
        /// Can be overriden to dispose any managed instances.
        /// </summary>
        protected virtual void DisposeManagedInstance()
        {
        }

        /// <summary>
        /// Can be overriden to dispose any unmanaged instances.
        /// </summary>
        /// <remarks>
        /// Do not try to dispose <see cref="GeometryInformation" /> because this type already takes care of it.
        /// </remarks>
        protected virtual void DisposeUnmanagedInstance()
        {
        }

        /// <summary>
        /// Must be overridden to initialize the actual geometry (drawing it).
        /// </summary>
        /// <returns>The geometry information.</returns>
        protected abstract GeometryInformation? InitGeometry();

        /// <summary>
        /// Internal dispose implementation.
        /// </summary>
        /// <param name="disposing">
        /// Is set to <c>true</c> if it got called by <see cref="Dispose" /> which means not called by the
        /// destructor.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                // The caller called Dispose explicitely so we can dispose managed types here.
                DisposeManagedInstance();
            }
            // In any case (even if Dispose() call was missed by caller) dispose unmanaged types.
            if (GeometryInformation != null)
            {
                DrawingHelper.CleanupWindow(GeometryInformation);
            }
            DisposeUnmanagedInstance();
            _isDisposed = true;
        }

        /// <summary>
        /// Finalizer.
        /// </summary>
        ~BaseGeometry()
        {
            Dispose(false);
        }

        #endregion

        #region properties

        protected GeometryInformation? GeometryInformation { get; private set; }

        protected nint? Handle => _windowContext?.Handle;

        #endregion
    }
}