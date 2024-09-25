using Microsoft.Extensions.Logging;
using Nimbus.Platform.Logic.Providers;
using Nimbus.Platform.Logic.Repositories;

namespace Nimbus.Platform.Logic.Managers
{
    public class WeatherManager(ILogger<WeatherManager> logger, IWeatherRepository weatherRepository, IGeolocationProvider geolocationProvider) : IWeatherManager
    {
        private readonly ILogger<WeatherManager> _logger = logger;
        private readonly IWeatherRepository _weatherRepository = weatherRepository;
        private readonly IGeolocationProvider _geolocationProvider = geolocationProvider;

        public Task<string> GetCurrentWeatherAsync()
        {
            var currentLocation = _geolocationProvider.GetCurrentLocation();
            if(currentLocation == null)
            {
                _logger.LogError($"{nameof(GetCurrentWeatherAsync)}: Failed to get current location.");
                return Task.FromResult(string.Empty);
            }

            return _weatherRepository.GetWeatherResultAsync(currentLocation.Longitude, currentLocation.Latitude);
        }
    }
}
