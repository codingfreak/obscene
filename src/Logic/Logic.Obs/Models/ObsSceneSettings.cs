namespace codingfreaks.obscene.Logic.Obs.Models
{
    using System.Drawing;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents data which can be read from OBS scene data files.
    /// </summary>
    public class ObsSceneSettings
    {
        #region properties

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("current_scene")]
        public string CurrentScene { get; set; } = null!;

        [JsonPropertyName("resolution")]
        public Size Resolution { get; set; }

        [JsonPropertyName("sources")]
        public ObsScene[] Scenes { get; set; } = null!;

        #endregion
    }
}
