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
