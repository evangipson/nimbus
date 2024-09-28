using Nimbus.Platform.Domain.Models;

namespace Nimbus.Platform.Logic.Repositories
{
    /// <summary>
    /// A repository that performs units of work on <see cref="Weather"/>.
    /// </summary>
    public interface IWeatherRepository
    {
        /// <summary>
        /// Queries the weather provider, and maps the result to <see cref="Weather"/>.
        /// </summary>
        /// <param name="longitude">
        /// The longitude to get the weather for.
        /// </param>
        /// <param name="latitude">
        /// The latitude to tget the weather for.
        /// </param>
        /// <returns>
        /// The current <see cref="Weather"/>.
        /// </returns>
        Task<Weather?> GetWeatherResultAsync(double longitude, double latitude);
    }
}
