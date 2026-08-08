using System;
using System.Linq;

namespace codingfreaks.obscene.Logic.Abstracts.Models
{
    using System.Drawing;

    /// <summary>
    /// Represents the part of the <see cref="SettingsData" /> related to the app display and behavior.
    /// </summary>
    public class AppSettingsData
    {
        #region properties

        public bool TopMost { get; set; }

        public bool IsDarkMode { get; set; } = true;

        public Size? MainFormSize { get; set; }

        public Point? MainFormLocation { get; set; }

        #endregion
    }
}
