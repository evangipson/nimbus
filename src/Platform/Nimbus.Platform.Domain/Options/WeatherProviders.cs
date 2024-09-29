namespace Nimbus.Platform.Domain.Options
{
    /// <summary>
    /// A model which represents a collection of weather provider <see cref="Uri"/> values, which is defined in the application settings.
    /// </summary>
    public class WeatherProviders : ApplicationSettings<Uri>
    {
    }
}
