namespace codingfreaks.obscene.Logic.Abstracts.Models
{
    using System.Text.Json;

    /// <summary>
    /// Represents the root element structure of the obscene settings.
    /// </summary>
    public class Settings
    {
        #region constants

        private static JsonSerializerOptions _jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        #endregion

        #region methods

        public static async ValueTask<Settings> LoadAsync(string filePath)
        {
            var json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<Settings>(json, _jsonSerializerOptions)
                   ?? throw new InvalidOperationException("Invalid file content.");
        }

        public async Task SaveAsync(string filePath)
        {
            var json = JsonSerializer.Serialize(this, _jsonSerializerOptions);
            await File.WriteAllTextAsync(filePath, json);
        }

        #endregion

        #region properties

        public Dictionary<string, Scene> Scenes { get; set; } = new();

        #endregion
    }
}
