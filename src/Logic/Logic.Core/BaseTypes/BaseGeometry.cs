namespace codingfreaks.obscene.Logic.Core.BaseTypes
{
    using Abstracts.Enumerations;
    using Abstracts.Interfaces;

    using System.Drawing;
    using System.Text.Json.Serialization;

    using Geometries;

    using WinApi;
    using WinApi.Models;

    using Rectangle = System.Drawing.Rectangle;

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
        public Color? BorderColor
        {
            get;
            set
            {
                field = value;
                Refresh();
            }
        }

        /// <inheritdoc />
        public int? BorderWidth
        {
            get;
            set
            {
                field = value;
                Refresh();
            }
        }

        /// <inheritdoc />
        public void Draw()
        {
            _windowContext = DrawingHelper.InitializeWindow(Position, Size);
            GeometryInformation = InitGeometry();
        }

        /// <inheritdoc />
        public Color FillColor
        {
            get;
            set
            {
                field = value;
                Refresh();
            }
        } = Color.FromArgb(50, Color.Red);

        /// <inheritdoc />
        public Point Position
        {
            get;
            set
            {
                if (!BeforePositionChange(ref value))
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
            if (GeometryInformation == null)
            {
                return;
            }
            GeometryInformation = DrawingHelper.MoveAndResizeGeometry(
                GeometryType,
                GeometryInformation,
                Position,
                Size,
                FillColor,
                BorderColor,
                BorderWidth);
        }

        /// <inheritdoc />
        public Size Size
        {
            get;
            set
            {
                if (!BeforeSizeChange(ref value))
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
        protected virtual bool BeforePositionChange(ref Point value)
        {
            return true;
        }

        /// <summary>
        /// Can be overridden by children to react before size changes.
        /// </summary>
        /// <param name="value">The new value that should be applied.</param>
        /// <returns><c>true</c> if the value should be accepted, otherwise <c>false</c>.</returns>
        protected virtual bool BeforeSizeChange(ref Size value)
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
        protected virtual GeometryInformation InitGeometry()
        {
            if (Handle == null)
            {
                throw new InvalidOperationException("No handle was present.");
            }
            return DrawingHelper.DrawGeometry(GeometryType, Handle.Value, Position, Size, FillColor, BorderColor);
        }

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

        /// <inheritdoc/>
        public abstract GeometryType GeometryType { get; }

        /// <summary>
        /// The WinAPI information of the current geometry.
        /// </summary>
        protected GeometryInformation? GeometryInformation { get; private set; }

        /// <summary>
        /// The handle of the window.
        /// </summary>
        protected nint? Handle => _windowContext?.Handle;

        #endregion
    }
}
