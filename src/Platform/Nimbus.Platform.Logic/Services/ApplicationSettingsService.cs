using Microsoft.Extensions.Options;

using Nimbus.Platform.Domain.Options;
using Nimbus.Platform.Domain.Constants;
using Nimbus.Platform.Logic.Extensions;

namespace Nimbus.Platform.Logic.Services
{
    /// <inheritdoc cref="IApplicationSettingsService"/>
    public class ApplicationSettingsService(IOptions<Databases> databaseSettings, IOptions<WeatherProviders> weatherProviderSettings) : IApplicationSettingsService
    {
        private readonly IOptions<Databases> _databaseSettings = databaseSettings;
        private readonly IOptions<WeatherProviders> _weatherProviderSettings = weatherProviderSettings;

        public string GetDatabase(string databaseName)
        {
            var database = _databaseSettings.GetSetting(databaseName);
            return database ?? throw new InvalidOperationException($"Failed to find the database: {databaseName}. Make sure it's defined in the application settings."); ;
        }

        public Uri GetWeatherProviderUri(string? weatherProviderName = null)
        {
            var weatherProviderKey = weatherProviderName ?? ApplicationSettingsConstants.DefaultWeatherProvider;
            var weatherProvider = _weatherProviderSettings.GetSetting(weatherProviderKey);
            return weatherProvider ?? throw new InvalidOperationException($"Failed to find the weather provider: {weatherProviderKey}. Make sure it's defined in the application settings.");
        }
    }
}
