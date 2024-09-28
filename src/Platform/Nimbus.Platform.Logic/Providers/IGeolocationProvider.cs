using Nimbus.Platform.Domain.Models;

namespace Nimbus.Platform.Logic.Providers
{
    /// <summary>
    /// A provider that interacts with a <see cref="Geolocation"/>.
    /// </summary>
    public interface IGeolocationProvider
    {
        /// <summary>
        /// Gets the current <see cref="Geolocation"/>.
        /// </summary>
        /// <returns>
        /// The current <see cref="Geolocation"/>.
        /// </returns>
        Geolocation? GetCurrentLocation();
    }
}
