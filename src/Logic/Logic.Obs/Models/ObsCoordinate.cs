namespace codingfreaks.obscene.Logic.Obs.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a X-Y coordinate in the OBS JSON file.
    /// </summary>
    /// <remarks>
    /// OBS seems to use this not only for coordinates but for all sors of tuples.
    /// </remarks>
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

        /// <summary>
        /// The value of X.
        /// </summary>
        [JsonPropertyName("x")]
        public double X { get; set; }

        /// <summary>
        /// The value of Y.
        /// </summary>
        [JsonPropertyName("y")]
        public double Y { get; set; }

        #endregion
    }
}
