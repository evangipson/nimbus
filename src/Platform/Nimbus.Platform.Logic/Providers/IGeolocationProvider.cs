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
        /// <para>
        /// Will throw an <see cref="InvalidOperationException"/> if the <see cref="Geolocation"/>
        /// can not be found.
        /// </para>
        /// </summary>
        /// <returns>
        /// The current <see cref="Geolocation"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        Geolocation GetCurrentLocation();
    }
}
