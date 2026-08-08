namespace codingfreaks.obscene.Logic.Abstracts.Models
{
    /// <summary>
    /// Defines the data structure which defines some basic app configuration.
    /// </summary>
    public class AppConfig
    {
        #region properties

        /// <summary>
        /// The absolute URI under which to store app settings.
        /// </summary>
        public string SettingsPath { get; set; } = null!;

        /// <summary>
        /// The UDP port on which to connect to OBS.
        /// </summary>
        public int ObsPort { get; set; } = 4455;

        /// <summary>
        /// The password to connect to OBS.
        /// </summary>
        public string? ObsPassword { get; set; }

        /// <summary>
        /// Retrieves the default app configuration.
        /// </summary>
        public static AppConfig Default =>
            new()
            {
                SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            };

        #endregion
    }
}
