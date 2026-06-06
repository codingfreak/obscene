namespace codingfreaks.obscene.Logic.Core
{
    using Abstracts.Interfaces;

    /// <summary>
    /// Represents a single scene
    /// </summary>
    public class Scene : ICloneable
    {
        #region explicit interfaces

        /// <inheritdoc />
        public object Clone()
        {
            return new Scene
            {
                // strings are immutable — assignment is safe, no copy needed
                Name = Name,
                ObsDeviceName = ObsDeviceName,
                // Deep copy: new list with individually cloned geometries
                Geometries = Geometries.Select(g => (IGeometry)g.Clone())
                    .ToList()
            };
        }

        #endregion

        #region properties

        /// <summary>
        /// The name of the scene.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// The OBS device name.
        /// </summary>
        public string ObsDeviceName { get; set; } = null!;

        /// <summary>
        /// The geometries to draw when the scene is active.
        /// </summary>
        public List<IGeometry> Geometries { get; set; } = new();

        #endregion
    }
}
