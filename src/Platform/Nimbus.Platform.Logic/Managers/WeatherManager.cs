using Nimbus.Platform.Domain.Models;
using Nimbus.Platform.Logic.Providers;
using Nimbus.Platform.Logic.Repositories;
using Nimbus.Platform.Logic.Services;

namespace Nimbus.Platform.Logic.Managers
{
    /// <inheritdoc cref="IWeatherManager"/>
    public class WeatherManager(IWeatherRepository weatherRepository, IGeolocationProvider geolocationProvider, IApplicationSettingsService applicationSettingsService) : IWeatherManager
    {
        private readonly IWeatherRepository _weatherRepository = weatherRepository;
        private readonly IGeolocationProvider _geolocationProvider = geolocationProvider;
        private readonly IApplicationSettingsService _applicationSettingsService = applicationSettingsService;

        public Task<WeatherForecast> GetCurrentWeatherAsync()
        {
            var weatherProviderUri = _applicationSettingsService.GetWeatherProviderUri();
            var currentLocation = _geolocationProvider.GetCurrentLocation();
            return _weatherRepository.GetWeatherResultAsync(weatherProviderUri, currentLocation.Longitude, currentLocation.Latitude);
        }
    }
}
