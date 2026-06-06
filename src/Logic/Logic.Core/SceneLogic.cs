namespace codingfreaks.obscene.Logic.Core
{
    using Abstracts.Enumerations;
    using Abstracts.Interfaces;
    using Abstracts.Models;

    using Extensions;

    using Geometries;

    /// <summary>
    /// Central logic to handle all screen drawings during the program runtime.
    /// </summary>
    public class SceneLogic
    {
        #region constructors and destructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="settings">The loaded settings to use.</param>
        public SceneLogic(Settings settings)
        {
            Settings = settings;
            ResolveGeometries();
        }

        #endregion

        #region methods

        /// <summary>
        /// Clears all content of the current scene from the screen.
        /// </summary>
        public void Clear()
        {
            if (CurrentScene == null)
            {
                return;
            }
            foreach (var geo in CurrentScene.ResolvedGeometries)
            {
                // TODO This works on the first switch of a scene but then stops working
                geo.Dispose();
            }
            CurrentScene.ResolvedGeometries.Clear();
            ResolveGeometries();
        }

        /// <summary>
        /// Draws the content of the scene with the given <paramref name="sceneName" /> to the screen.
        /// </summary>
        /// <param name="sceneName">The name of the scene to show.</param>
        public void Draw(string sceneName)
        {
            if (CurrentScene?.Name != sceneName)
            {
                // we have to clear first
                Clear();
            }
            CurrentScene = Settings.Scenes[sceneName];
            foreach (var geo in CurrentScene.ResolvedGeometries)
            {
                geo.Draw();
            }
        }

        /// <summary>
        /// TODO HACK!!! 😒😒😒😒😒😒😒😒😒😒😒😒
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public void ResolveGeometries()
        {
            foreach (var scene in Settings.Scenes)
            {
                if (scene.Value.ResolvedGeometries.Any())
                {
                    continue;
                }
                foreach (var loadedGeo in scene.Value.Geometries)
                {
                    scene.Value.ResolvedGeometries.Add(ResolveGeometry(loadedGeo));
                }
            }
        }

        /// <summary>
        /// TODO HACK!!! 😒😒😒😒😒😒😒😒😒😒😒😒
        /// </summary>
        /// <param name="loadedGeo"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static IGeometry ResolveGeometry(Geometry loadedGeo)
        {
            switch (loadedGeo.GeometryType)
            {
                case GeometryType.Rectangle:
                    return new Rectangle
                    {
                        Position = loadedGeo.Position,
                        Size = loadedGeo.Size,
                        BorderColor = loadedGeo.BorderColor?.ToColor(),
                        BorderWidth = loadedGeo.BorderWidth,
                        FillColor = loadedGeo.FillColor.ToColor()
                    };
                case GeometryType.Ellipse:
                    if (loadedGeo.Size.Width == loadedGeo.Size.Height)
                    {
                        return new Circle
                        {
                            Position = loadedGeo.Position,
                            Size = loadedGeo.Size,
                            BorderColor = loadedGeo.BorderColor?.ToColor(),
                            BorderWidth = loadedGeo.BorderWidth,
                            FillColor = loadedGeo.FillColor.ToColor()
                        };
                    }
                    return new Ellipse
                    {
                        Position = loadedGeo.Position,
                        Size = loadedGeo.Size,
                        BorderColor = loadedGeo.BorderColor?.ToColor(),
                        BorderWidth = loadedGeo.BorderWidth,
                        FillColor = loadedGeo.FillColor.ToColor()
                    };
            }
            throw new InvalidOperationException("Could not resolve geometry.");
        }

        #endregion

        #region properties

        /// <summary>
        /// The currently selected scene.
        /// </summary>
        /// <remarks>
        /// Use <see cref="Draw" /> to switch the scene.
        /// </remarks>
        public Scene? CurrentScene { get; private set; }

        /// <summary>
        /// The settings to use.
        /// </summary>
        public Settings Settings { get; }

        #endregion
    }
}
