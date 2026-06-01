namespace codingfreaks.obscene.Logic.Obs.Models
{
    using System.Text.Json.Serialization;

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

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("source_uuid")]
        public string SourceUuid { get; set; } = null!;

        [JsonPropertyName("visible")]
        public bool IsVisible { get; set; }

        [JsonPropertyName("locked")]
        public bool IsLocked { get; set; }

        public double rot { get; set; }

        public int align { get; set; }

        public int bounds_type { get; set; }

        public int bounds_align { get; set; }

        public bool bounds_crop { get; set; }

        public int crop_left { get; set; }

        public int crop_top { get; set; }

        public int crop_right { get; set; }

        public int crop_bottom { get; set; }

        [JsonPropertyName("pos")]
        public ObsCoordinate Position { get; set; } = null!;

        [JsonPropertyName("pos_rel")]
        public ObsCoordinate RelativePosition { get; set; } = null!;

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
