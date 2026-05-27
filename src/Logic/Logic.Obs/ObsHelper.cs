namespace codingfreaks.obscene.Logic.Obs
{
    using System.Text.Json;

    using Abstracts.Models;

    public static class ObsHelper
    {
        #region methods

        public static async ValueTask<ObsSettings> LoadSettingsAsync(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }
            var fileContent = await File.ReadAllTextAsync(fileName);
            try
            {
                var settings = JsonSerializer.Deserialize<ObsSettings>(fileContent);
                return settings ?? throw new InvalidOperationException("Invalid OBS settings file.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not load settings from file '{fileName}'.", ex);
            }
        }

        #endregion
    }
}
