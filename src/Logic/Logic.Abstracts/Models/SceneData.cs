namespace codingfreaks.obscene.Logic.Abstracts.Models
{
    /// <summary>
    /// Represents scene information on (de-)serialization.
    /// </summary>
    public class SceneData
    {
        #region properties

        /// <summary>
        /// The name of the scene,
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// The name of the respective device in OBS.
        /// </summary>
        public string ObsDeviceName { get; set; } = null!;

        /// <summary>
        /// The associated geometries information.
        /// </summary>
        public GeometryData[] Geometries { get; set; } = [];

        #endregion
    }
}
