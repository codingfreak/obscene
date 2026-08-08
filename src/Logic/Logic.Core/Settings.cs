namespace codingfreaks.obscene.Logic.Core
{
    using System.Text.Json;

    using Abstracts.Models;

    using Extensions;

    using Microsoft.Win32;

    /// <summary>
    /// Represents the root element structure of the obscene settings.
    /// </summary>
    public class Settings
    {
        #region constants

        /// <summary>
        /// The name of the config file.
        /// </summary>
        public static readonly string AppConfigFileName = "obscene.config";

        /// <summary>
        /// The name of the app.
        /// </summary>
        private const string AppName = "obscene";

        /// <summary>
        /// The name of the settings file.
        /// </summary>
        private const string AppSettingsFileName = "obscene.json";

        /// <summary>
        /// The registry key under which to configure the auto-start.
        /// </summary>
        private const string AutoStartRegistryKey = @"Software\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// The default JSON serializer options to use.
        /// </summary>
        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        #endregion

        #region methods

        /// <summary>
        /// The path where the settings should be stored at and loaded from.
        /// </summary>
        public static async ValueTask<string> GetConfigPathAsync()
        {
            var config = await LoadConfigAsync();
            return Path.Combine(config.SettingsPath, AppSettingsFileName);
        }

        /// <summary>
        /// Retrieves if the current application is configured in auto-start.
        /// </summary>
        /// <returns><c>true</c> if auto-start is enabled, otherwise <c>false</c>.</returns>
        public static bool GetIsAutostartEnabled()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(AutoStartRegistryKey, false))
            {
                return key?.GetValue(AppName) is string v && string.Equals(
                    v,
                    Environment.ProcessPath!,
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Loads and transforms the settings from the configured path.
        /// </summary>
        /// <returns>The deserialized settings instance.</returns>
        /// <exception cref="FileNotFoundException">Is thrown if the settings path leads to a non-existing file.</exception>
        /// <exception cref="InvalidOperationException">Is trown if the deserialization fails.</exception>
        public static async ValueTask<Settings> LoadAsync()
        {
            var filePath = await GetConfigPathAsync();
            if (!File.Exists(filePath))
            {
                return new Settings();
            }
            var json = await File.ReadAllTextAsync(filePath);
            var data = JsonSerializer.Deserialize<SettingsData>(json, JsonSerializerOptions)
                       ?? throw new InvalidOperationException("Invalid file content.");
            return data.ToSettings();
        }

        /// <summary>
        /// Retrieves the current app configuration.
        /// </summary>
        /// <remarks>
        /// Loads it either from the <see cref="AppConfigFileName" /> or retrieves the <see cref="AppConfig.Default" />.
        /// </remarks>
        /// <returns>The app configuration.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static async ValueTask<AppConfig> LoadConfigAsync()
        {
            if (File.Exists(AppConfigFileName))
            {
                var content = await File.ReadAllTextAsync(AppConfigFileName);
                var result = JsonSerializer.Deserialize<AppConfig>(content);
                if (result == null)
                {
                    // delete corrupted file
                    File.Delete(AppConfigFileName);
                    return AppConfig.Default;
                }
                return result;
            }
            return AppConfig.Default;
        }

        /// <summary>
        /// Stores the data of the current instance as JSON to the configured path.
        /// </summary>
        public async Task SaveAsync()
        {
            var data = this.ToSettingsData();
            var json = JsonSerializer.Serialize(data, JsonSerializerOptions);
            var path = await GetConfigPathAsync();
            await File.WriteAllTextAsync(path, json);
        }

        /// <summary>
        /// Stores the given <paramref name="newConfig" /> in the <see cref="AppConfigFileName" />.
        /// </summary>
        /// <param name="newConfig"></param>
        /// <returns></returns>
        public static async Task SaveConfigAsync(AppConfig newConfig)
        {
            var currentConfig = await LoadConfigAsync();
            if (currentConfig.SettingsPath != newConfig.SettingsPath)
            {
                var currentSetttingsFile = await GetConfigPathAsync();
                if (File.Exists(currentSetttingsFile))
                {
                    // We need to move any existing newConfig to the new location
                    var newSettingsFile = Path.Combine(newConfig.SettingsPath, AppSettingsFileName);
                    File.Move(currentSetttingsFile, newSettingsFile);
                }
            }
            var content = JsonSerializer.Serialize(newConfig);
            await File.WriteAllTextAsync(AppConfigFileName, content);
        }

        /// <summary>
        /// Configures the auto-start for the current application.
        /// </summary>
        /// <param name="enable"><c>true</c> if it should be enabled, <c>false</c> if it should be disabled.</param>
        public static void SetAutostart(bool enable)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(AutoStartRegistryKey, true) ?? Registry.CurrentUser.CreateSubKey(AutoStartRegistryKey))
            {
                if (enable)
                {
                    key.SetValue(AppName, Environment.ProcessPath!, RegistryValueKind.String);
                }
                else
                {
                    key.DeleteValue(AppName, false);
                }
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// The collection of scenes where the key is the scene name in OBS and the value the scene information.
        /// </summary>
        public Dictionary<string, Scene> Scenes { get; set; } = new();

        /// <summary>
        /// The options for the app behavior and display.
        /// </summary>
        public AppSettings AppSettings { get; set; } = new();

        #endregion
    }
}
