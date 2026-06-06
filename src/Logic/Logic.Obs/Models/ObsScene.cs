namespace codingfreaks.obscene.Logic.Obs.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a siingle scene in the OBS JSON file.
    /// </summary>
    public class ObsScene
    {
        #region methods

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Scene {Name}";
        }

        #endregion

        #region properties

        /// <summary>
        /// The name of the scene.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// The unique id.
        /// </summary>
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; } = null!;

        /// <summary>
        /// The internal id.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The settings for this scene.
        /// </summary>
        [JsonPropertyName("settings")]
        public ObsSceneSetting Settings { get; set; } = null!;

        #endregion
    }
}
