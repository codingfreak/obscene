namespace codingfreaks.obscene.Logic.Obs.Models
{
    using System.Text.Json.Serialization;

    public class ObsSceneSettings
    {
        #region properties

        [JsonPropertyName("custom_size")]
        public bool IsCustomSize { get; set; }

        [JsonPropertyName("items")]
        public ObsSceneDevice[] Devices { get; set; } = null!;

        [JsonPropertyName("monitor_id")]
        public string MonitorId { get; set; } = null!;

        [JsonPropertyName("resolution")]
        public string Resolution { get; set; } = null!;

        [JsonPropertyName("video_format")]
        public int VideoFormat { get; set; }

        [JsonPropertyName("active")]
        public bool IsActive { get; set; }

        [JsonPropertyName("device_id")]
        public string DeviceId { get; set; } = null!;

        #endregion
    }
}
