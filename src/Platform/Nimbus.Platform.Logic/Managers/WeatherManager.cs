using Microsoft.Extensions.Logging;

using Nimbus.Platform.Domain.Models;
using Nimbus.Platform.Logic.Providers;
using Nimbus.Platform.Logic.Repositories;

namespace Nimbus.Platform.Logic.Managers
{
    /// <inheritdoc cref="IWeatherManager"/>
    public class WeatherManager(ILogger<WeatherManager> logger, IWeatherRepository weatherRepository, IGeolocationProvider geolocationProvider) : IWeatherManager
    {
        private readonly ILogger<WeatherManager> _logger = logger;
        private readonly IWeatherRepository _weatherRepository = weatherRepository;
        private readonly IGeolocationProvider _geolocationProvider = geolocationProvider;

        public Task<Weather?> GetCurrentWeatherAsync()
        {
            var currentLocation = _geolocationProvider.GetCurrentLocation();
            if(currentLocation == null)
            {
                _logger.LogError($"{nameof(GetCurrentWeatherAsync)}: Failed to get current location.");
                return Task.FromResult(default(Weather));
            }

            return _weatherRepository.GetWeatherResultAsync(currentLocation.Longitude, currentLocation.Latitude);
        }
    }
}
