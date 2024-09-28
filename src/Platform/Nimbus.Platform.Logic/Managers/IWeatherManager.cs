using Nimbus.Platform.Domain.Models;

namespace Nimbus.Platform.Logic.Managers
{
    /// <summary>
    /// A manager that is responsible for interacting with the <see cref="Weather"/>.
    /// </summary>
    public interface IWeatherManager
    {
        /// <summary>
        /// Gets the current <see cref="Weather"/>.
        /// </summary>
        /// <returns>
        /// The current <see cref="Weather"/>.
        /// </returns>
        Task<Weather?> GetCurrentWeatherAsync();
    }
}
