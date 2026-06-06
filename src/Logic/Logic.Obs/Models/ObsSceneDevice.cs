namespace codingfreaks.obscene.Logic.Obs.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a single device of a scene in the OBS JSON file.
    /// </summary>
    public class ObsSceneDevice
    {
        #region methods

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Device {Name} ({Position})";
        }

        #endregion

        #region properties

        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The device name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("source_uuid")]
        public string SourceUuid { get; set; } = null!;

        [JsonPropertyName("visible")]
        public bool IsVisible { get; set; }

        [JsonPropertyName("locked")]
        public bool IsLocked { get; set; }

        /// <summary>
        /// The position of the device on the screen.
        /// </summary>
        [JsonPropertyName("pos")]
        public ObsCoordinate Position { get; set; } = null!;

        /// <summary>
        /// The relative position of the device on the screeen.
        /// </summary>
        [JsonPropertyName("pos_rel")]
        public ObsCoordinate RelativePosition { get; set; } = null!;

        /// <summary>
        /// The scale-factor.
        /// </summary>
        [JsonPropertyName("scale")]
        public ObsCoordinate Scale { get; set; } = null!;

        [JsonPropertyName("scale_ref")]
        public ObsCoordinate ScaleReference { get; set; } = null!;

        [JsonPropertyName("bounds")]
        public ObsCoordinate Bounds { get; set; } = null!;

        [JsonPropertyName("bounds_rel")]
        public ObsCoordinate RelativeBounds { get; set; } = null!;

        [JsonPropertyName("scale_filter")]
        public string ScaleFilter { get; set; } = null!;

        #endregion
    }
}
