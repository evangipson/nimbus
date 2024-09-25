using System.Net;
using Microsoft.Extensions.Logging;
using MaxMind.GeoIP2;

using Nimbus.Platform.Domain.Models;
using Nimbus.Platform.Logic.Services;
using System.Net.Sockets;
using MaxMind.GeoIP2.Responses;

namespace Nimbus.Platform.Logic.Providers
{
    public class GeolocationProvider(ILogger<GeolocationProvider> logger, IEnvironmentService environmentService): IGeolocationProvider
    {
        private readonly ILogger<GeolocationProvider> _logger = logger;
        private readonly IEnvironmentService _environmentService = environmentService;

        public Geolocation? GetCurrentLocation()
        {
            var ipAddress = GetPublicIpAddress();
            if(ipAddress == null)
            {
                _logger.LogError($"{nameof(GetCurrentLocation)}: Failed to get IP address for location lookup.");
                return null;
            }
            _logger.LogInformation($"{nameof(GetCurrentLocation)}: IP address \"{ipAddress.ToString()}\" discovered.");

            var geolocationDatabase = _environmentService.GetDatabase("Geolocation");
            using var reader = new DatabaseReader(geolocationDatabase);
            if(!reader.TryCity(ipAddress, out var cityResponse))
            {
                _logger.LogError($"{nameof(GetCurrentLocation)}: Failed to get City from Geolocation database for location lookup.");
                return null;
            }
            _logger.LogInformation($"{nameof(GetCurrentLocation)}: City \"{cityResponse?.City.Name}\" discovered.");

            return new Geolocation
            {
                Latitude = cityResponse?.Location.Latitude ?? default,
                Longitude = cityResponse?.Location.Longitude ?? default
            };
        }

        /// <summary>
        /// Gets the public IP address of the server.
        /// </summary>
        /// <returns></returns>
        private IPAddress? GetPublicIpAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList
                .Where(address => address.AddressFamily == AddressFamily.InterNetworkV6)
                .Where(address => !address.ToString().StartsWith("fe80::"))
                .FirstOrDefault();
        }
    }
}
