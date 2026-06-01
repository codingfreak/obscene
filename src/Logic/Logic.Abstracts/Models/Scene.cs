namespace codingfreaks.obscene.Logic.Abstracts.Models
{
    using Interfaces;

    public class Scene
    {
        #region properties

        public string Name { get; set; } = null!;

        public string DeviceName { get; set; } = null!;

        public List<Geometry> Geometries { get; set; } = new();

        public List<IGeometry> ResolvedGeometries { get; set; } = new();

        #endregion
    }
}
