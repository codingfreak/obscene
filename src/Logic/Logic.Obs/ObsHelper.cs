namespace codingfreaks.obscene.Logic.Obs
{
    using System.Text.Json;

    using Models;

    /// <summary>
    /// Provides helper methods for access to OBS information.
    /// </summary>
    public static class ObsHelper
    {
        #region methods

        /// <summary>
        /// Retrieves the device information from OBS.
        /// </summary>
        /// <param name="filePath">The absolute path to the OBS scene export file.</param>
        /// <param name="sceneName">The Name of the scene.</param>
        /// <param name="deviceName">The Name of the device on the <paramref Name="sceneName" />.</param>
        /// <returns>The device information.</returns>
        /// <exception cref="InvalidOperationException">If scene or device are not found.</exception>
        public static async ValueTask<ObsSceneDevice> GetObsCameraSettingsAsync(
            string filePath,
            string sceneName,
            string deviceName)
        {
            var settings = await LoadSettingsAsync(filePath);
            Console.WriteLine("Settings loaded.");
            var bottomRight = settings.Scenes.FirstOrDefault(s => s.Name == sceneName);
            if (bottomRight == null)
            {
                throw new InvalidOperationException("Could not find scene.");
            }
            var cameraItem = bottomRight.Settings.Devices.FirstOrDefault(i => i.Name == deviceName);
            if (cameraItem == null)
            {
                throw new InvalidOperationException("Could not find camera device.");
            }
            return cameraItem;
        }

        /// <summary>
        /// Tries to load the OBS scene settings from the expected default location.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static async ValueTask<Dictionary<string, ObsSettings>> LoadDefaultSceneSettingsAsync()
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "obs-studio",
                "basic",
                "scenes");
            var dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                throw new DirectoryNotFoundException($"Default expected OBS scene dir '{path}' not found.");
            }
            var result = new Dictionary<string, ObsSettings>();
            foreach (var file in dirInfo.GetFiles("*.json"))
            {
                var settings = await LoadSettingsAsync(file.FullName);
                result.Add(settings.Name, settings);
            }
            return result;
        }

        /// <summary>
        /// Trues to load the OBS scene settings from the provided <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath">The absolute path of the file.</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static async ValueTask<ObsSettings> LoadSettingsAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            var fileContent = await File.ReadAllTextAsync(filePath);
            try
            {
                var settings = JsonSerializer.Deserialize<ObsSettings>(fileContent);
                return settings ?? throw new InvalidOperationException("Invalid OBS settings file.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not load settings from file '{filePath}'.", ex);
            }
        }

        #endregion
    }
}
