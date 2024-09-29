using Nimbus.Platform.Domain.Models;

namespace Nimbus.Platform.Logic.Repositories
{
    /// <summary>
    /// A repository that performs units of work on a <see cref="WeatherForecast"/>.
    /// </summary>
    public interface IWeatherRepository
    {
        /// <summary>
        /// Queries the weather provider, and maps the result to a <see cref="WeatherForecast"/>.
        /// <para>
        /// Will throw an <see cref="InvalidOperationException"/> if the <see cref="WeatherForecast"/> is not retrieved.
        /// </para>
        /// </summary>
        /// <param name="weatherProviderUri">
        /// The <see cref="Uri"/> of the weather provider.
        /// </param>
        /// <param name="longitude">
        /// The longitude to get the weather for.
        /// </param>
        /// <param name="latitude">
        /// The latitude to tget the weather for.
        /// </param>
        /// <returns>
        /// The current <see cref="WeatherForecast"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        Task<WeatherForecast> GetWeatherResultAsync(Uri weatherProviderUri, double longitude, double latitude);
    }
}
