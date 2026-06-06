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
        /// The collection of scenes where the key is the scene name in OBS and the value the scene information.
        /// </summary>
        public ReadOnlyDictionary<string, SceneData> Scenes { get; set; } = ReadOnlyDictionary<string, SceneData>.Empty;

        #endregion
    }
}
