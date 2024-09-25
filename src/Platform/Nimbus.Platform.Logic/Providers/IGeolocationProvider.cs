using Nimbus.Platform.Domain.Models;

namespace Nimbus.Platform.Logic.Providers
{
    public interface IGeolocationProvider
    {
        Geolocation? GetCurrentLocation();
    }
}
