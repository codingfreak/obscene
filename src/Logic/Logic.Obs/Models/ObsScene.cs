namespace codingfreaks.obscene.Logic.Obs.Models
{
    using System.Text.Json.Serialization;

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

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("settings")]
        public ObsSceneSettings Settings { get; set; } = null!;

        #endregion
    }
}
