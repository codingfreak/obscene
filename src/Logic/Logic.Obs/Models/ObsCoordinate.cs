namespace codingfreaks.obscene.Logic.Obs.Models
{
    using System.Text.Json.Serialization;

    public class ObsCoordinate
    {
        #region methods

        /// <inheritdoc />
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }

        #endregion

        #region properties

        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonPropertyName("y")]
        public double Y { get; set; }

        #endregion
    }
}
