using Microsoft.Extensions.Logging;
using MaxMind.GeoIP2;

using Nimbus.Platform.Domain.Models;
using Nimbus.Platform.Logic.Services;

namespace Nimbus.Platform.Logic.Providers
{
    /// <inerhitdoc cref="IGeolocationProvider"/>
    public class GeolocationProvider(ILogger<GeolocationProvider> logger, IEnvironmentService environmentService, IIpAddressProvider ipAddressProvider): IGeolocationProvider
    {
        private readonly ILogger<GeolocationProvider> _logger = logger;
        private readonly IEnvironmentService _environmentService = environmentService;
        private readonly IIpAddressProvider _ipAddressProvider = ipAddressProvider;

        public Geolocation? GetCurrentLocation()
        {
            var ipAddress = _ipAddressProvider.GetPublicIpAddress();
            if(ipAddress == null)
            {
                _logger.LogError($"{nameof(GetCurrentLocation)}: Failed to get IP address for location lookup.");
                return null;
            }

            var geolocationDatabase = _environmentService.GetDatabase("Geolocation");
            using var reader = new DatabaseReader(geolocationDatabase);
            if(!reader.TryCity(ipAddress, out var cityResponse))
            {
                _logger.LogError($"{nameof(GetCurrentLocation)}: Failed to get City from Geolocation database for location lookup.");
                return null;
            }

            return new()
            {
                Latitude = cityResponse?.Location.Latitude ?? default,
                Longitude = cityResponse?.Location.Longitude ?? default
            };
        }
    }
}
