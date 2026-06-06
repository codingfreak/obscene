namespace codingfreaks.obscene.Logic.Core
{
    using System.Text.Json;

    using Abstracts.Models;

    using Extensions;

    /// <summary>
    /// Represents the root element structure of the obscene settings.
    /// </summary>
    public class Settings
    {
        #region constants

        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        #endregion

        #region methods

        /// <summary>
        /// Loads and transforms the settings from the given <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath">The path to the settings file.</param>
        /// <returns>The deserialized settings instance.</returns>
        /// <exception cref="FileNotFoundException">Is thrown if the <paramref name="filePath" /> could not be found.</exception>
        /// <exception cref="InvalidOperationException">Is trown if the deserialization fails.</exception>
        public static async ValueTask<Settings> LoadAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            var json = await File.ReadAllTextAsync(filePath);
            var data = JsonSerializer.Deserialize<SettingsData>(json, JsonSerializerOptions)
                       ?? throw new InvalidOperationException("Invalid file content.");
            return data.ToSettings();
        }

        /// <summary>
        /// Stores the data of the current instance as JSON to the given <paramref name="filePath" />.
        /// </summary>
        /// <param name="filePath">The path to the settings file.</param>
        public async Task SaveAsync(string filePath)
        {
            var data = this.ToSettingsData();
            var json = JsonSerializer.Serialize(data, JsonSerializerOptions);
            await File.WriteAllTextAsync(filePath, json);
        }

        #endregion

        #region properties

        /// <summary>
        /// The collection of scenes where the key is the scene name in OBS and the value the scene information.
        /// </summary>
        public Dictionary<string, Scene> Scenes { get; set; } = new();

        #endregion
    }
}
