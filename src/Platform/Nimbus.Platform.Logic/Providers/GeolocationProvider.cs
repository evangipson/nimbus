using Microsoft.Extensions.Logging;
using MaxMind.GeoIP2;

using Nimbus.Platform.Domain.Models;
using Nimbus.Platform.Logic.Services;

namespace Nimbus.Platform.Logic.Providers
{
    /// <inerhitdoc cref="IGeolocationProvider"/>
    public class GeolocationProvider(ILogger<GeolocationProvider> logger, IApplicationSettingsService environmentService, IIpAddressProvider ipAddressProvider): IGeolocationProvider
    {
        private readonly ILogger<GeolocationProvider> _logger = logger;
        private readonly IApplicationSettingsService _environmentService = environmentService;
        private readonly IIpAddressProvider _ipAddressProvider = ipAddressProvider;

        public Geolocation GetCurrentLocation()
        {
            var ipAddress = _ipAddressProvider.GetPublicIpAddress();
            var geolocationDatabase = _environmentService.GetDatabase("Geolocation");
            using var reader = GetDatabaseReader(geolocationDatabase);
            if(!reader.TryCity(ipAddress, out var cityResponse))
            {
                throw new InvalidOperationException($"{nameof(GetCurrentLocation)}: Failed to find the current city for location lookup.");
            }

            return new()
            {
                Latitude = cityResponse?.Location.Latitude ?? default,
                Longitude = cityResponse?.Location.Longitude ?? default
            };
        }

        /// <summary>
        /// Provides a <see cref="DatabaseReader"/> if a database exists at the provided
        /// <paramref name="databaseLocation"/>.
        /// <para>
        /// Will throw an <see cref="InvalidOperationException"/> if the database can not be found.
        /// </para>
        /// </summary>
        /// <param name="databaseLocation">
        /// A file path to the local database.
        /// </param>
        /// <returns>
        /// A new <see cref="DatabaseReader"/> scoped to the provided <paramref name="databaseLocation"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        private DatabaseReader GetDatabaseReader(string databaseLocation)
        {
            try
            {
                return new DatabaseReader(databaseLocation);
            }
            catch
            {
                throw new InvalidOperationException($"{nameof(GetDatabaseReader)}: Failed to find the {nameof(Geolocation)} database at the provided location: {databaseLocation}");
            }
        }
    }
}
