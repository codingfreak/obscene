namespace codingfreaks.obscene.Logic.Core.Extensions
{
    using System.Drawing;

    using Abstracts.Enumerations;
    using Abstracts.Interfaces;
    using Abstracts.Models;

    using Geometries;

    using Rectangle = Geometries.Rectangle;

    /// <summary>
    /// Provides extension methods used during settings conversion between serialized and implementation types.
    /// </summary>
    internal static class SettingsConversionExtensions
    {
        #region methods

        /// <summary>
        /// Converts the given <paramref name="original" /> serialization data into the internally used color type.
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static Color ToColor(this ColorData original)
        {
            return Color.FromArgb(original.A, original.R, original.G, original.B);
        }

        /// <summary>
        /// Converts the given <paramref name="original" /> internally used color type into the matching serialization data.
        /// </summary>
        public static ColorData ToColorData(this Color original)
        {
            return new ColorData
            {
                A = original.A,
                R = original.R,
                B = original.B,
                G = original.G
            };
        }

        /// <summary>
        /// Converts the given <paramref name="original" /> serialization data into the internally used geometry type.
        /// </summary>
        /// <remarks>
        /// This retrieves the interfaces based on the constructed type matching the <paramref name="original" /> data.
        /// </remarks>
        public static IGeometry ToGeometry(this GeometryData original)
        {
            IGeometry? result = null;
            switch (original.GeometryType)
            {
                case GeometryType.Rectangle:
                    result = new Rectangle();
                    break;
                case GeometryType.Ellipse:
                    result = original.Size.Height == original.Size.Width ? new Circle() : new Ellipse();
                    break;
            }
            if (result == null)
            {
                throw new ArgumentException("The geometry type could not be resolved.", nameof(original));
            }
            result.Position = original.Position;
            result.BorderColor = original.BorderColor?.ToColor();
            result.BorderWidth = original.BorderWidth;
            result.FillColor = original.FillColor.ToColor();
            result.Size = original.Size;
            return result;
        }

        /// <summary>
        /// Converts the given <paramref name="original" /> internally used geometry type into the matching serialization data.
        /// </summary>
        public static GeometryData ToGeometryData(this IGeometry original)
        {
            return new GeometryData
            {
                GeometryType = original.GeometryType,
                Position = original.Position,
                BorderColor = original.BorderColor?.ToColorData(),
                BorderWidth = original.BorderWidth,
                FillColor = original.FillColor.ToColorData(),
                Size = original.Size
            };
        }

        /// <summary>
        /// Converts the given <paramref name="original" /> serialization data into the internally used scene type.
        /// </summary>
        public static Scene ToScene(this SceneData original)
        {
            return new Scene
            {
                Name = original.Name,
                ObsDeviceName = original.ObsDeviceName,
                Geometries = original.Geometries.Select(g => g.ToGeometry())
                    .ToList()
            };
        }

        /// <summary>
        /// Converts the given <paramref name="original" /> internally used scene type into the matching serialization data.
        /// </summary>
        public static SceneData ToSceneData(this Scene original)
        {
            return new SceneData
            {
                Name = original.Name,
                ObsDeviceName = original.ObsDeviceName,
                Geometries = original.Geometries.Select(g => g.ToGeometryData())
                    .ToArray()
            };
        }

        /// <summary>
        /// Converts the given <paramref name="original" /> serialization data into the internally used type.
        /// </summary>
        public static Settings ToSettings(this SettingsData original)
        {
            return new Settings
            {
                Scenes = original.Scenes.ToDictionary(s => s.Key, s => s.Value.ToScene())
            };
        }

        /// <summary>
        /// Converts the given <paramref name="original" /> internally used settings type into the matching serialization data.
        /// </summary>
        public static SettingsData ToSettingsData(this Settings original)
        {
            return new SettingsData
            {
                Scenes = original.Scenes.ToDictionary(s => s.Key, s => s.Value.ToSceneData())
            };
        }

        #endregion
    }
}
