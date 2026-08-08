namespace codingfreaks.obscene.Logic.Abstracts.Models
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents settings information on (de-)serialization.
    /// </summary>
    public class SettingsData
    {
        #region properties

        /// <summary>
        /// The options for the app behavior and display.
        /// </summary>
        public AppSettingsData AppSettings { get; set; } = new();

        /// <summary>
        /// The collection of scenes where the key is the scene name in OBS and the value the scene information.
        /// </summary>
        public Dictionary<string, SceneData> Scenes { get; set; } = new();

        #endregion
    }
}
