namespace codingfreaks.obscene.Logic.Core
{
    using System.Drawing;

    /// <summary>
    /// Represents the part of the <see cref="Settings" /> related to the app display and behavior.
    /// </summary>
    public class AppSettings
    {
        #region properties

        public bool TopMost { get; set; }

        public bool IsDarkMode { get; set; } = true;

        public Size? MainFormSize { get; set; }

        public Point? MainFormLocation { get; set; }

        #endregion
    }
}
