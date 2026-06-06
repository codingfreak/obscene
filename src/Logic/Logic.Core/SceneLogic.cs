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
                // TODO This works on the first switch of a scene but then stops working
                geo.Dispose();
            }
            CurrentScene.Geometries.Clear();
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
