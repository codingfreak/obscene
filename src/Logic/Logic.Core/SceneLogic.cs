namespace codingfreaks.obscene.Logic.Core
{
    using Abstracts.Models;

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
            foreach (var geo in CurrentScene.Geometries)
            {
                geo.Dispose();
            }
            CurrentScene.Geometries.Clear();
            CurrentScene = null;
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
            CurrentScene = (Scene)Settings.Scenes[sceneName]
                .Clone();
            foreach (var geo in CurrentScene.Geometries)
            {
                geo.Draw();
            }
        }

        /// <summary>
        /// Refreshes all geometries of the current scene.
        /// </summary>
        //public void Refresh()
        //{
        //    if (CurrentScene == null)
        //    {
        //        throw new InvalidOperationException("No current scene selected.");
        //    }
        //    foreach (var geo in CurrentScene.Geometries)
        //    {
        //        geo.Refresh();
        //    }
        //}

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

        /// <summary>
        /// Refreshes all geometries of the current scene.
        /// </summary>
        /// <param name="scene"></param>
        public void RefreshCurrentScene(Scene scene)
        {
            if (CurrentScene == null)
            {
                return;
            }
            foreach (var geo in CurrentScene.Geometries)
            {
                var match = scene.Geometries.First(g => g.Id == geo.Id);
                geo.BorderColor = match.BorderColor;
                geo.BorderWidth = match.BorderWidth;
                geo.FillColor = match.FillColor;
                geo.Position = match.Position;
                geo.Size = match.Size;
                geo.Refresh();
            }

        #endregion
    }
}}
