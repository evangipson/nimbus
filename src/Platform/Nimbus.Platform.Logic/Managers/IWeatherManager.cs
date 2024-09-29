using Nimbus.Platform.Domain.Models;

namespace Nimbus.Platform.Logic.Managers
{
    /// <summary>
    /// A manager that is responsible for interacting with a <see cref="WeatherForecast"/>.
    /// </summary>
    public interface IWeatherManager
    {
        /// <summary>
        /// Gets the current <see cref="WeatherForecast"/>.
        /// </summary>
        /// <returns>
        /// The current <see cref="WeatherForecast"/>.
        /// </returns>
        Task<WeatherForecast> GetCurrentWeatherAsync();
    }
}
