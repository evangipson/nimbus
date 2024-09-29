using Nimbus.Platform.Domain.Constants;

namespace Nimbus.Platform.Logic.Services
{
    /// <summary>
    /// A service responsible for interacting with the application settings.
    /// </summary>
    public interface IApplicationSettingsService
    {
        /// <summary>
        /// Gets the path for a database from the application settings.
        /// <para>
        /// Will throw an <see cref="InvalidOperationException"/> if the requested
        /// database is not found.
        /// </para>
        /// </summary>
        /// <param name="databaseName">
        /// The name of the database to get from the application settings.
        /// </param>
        /// <returns>
        /// The desired database's path from the application settings.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        string GetDatabase(string databaseName);

        /// <summary>
        /// Gets a <see cref="Uri"/> for a weather provider from the application settings.
        /// <para>
        /// Will throw an <see cref="InvalidOperationException"/> if the requested
        /// weather provider is not found.
        /// </para>
        /// </summary>
        /// <param name="weatherProviderName">
        /// An optional name for a weather provider defined in the application settings.
        /// Defaults to <see cref="ApplicationSettingsConstants.DefaultWeatherProvider"/>.
        /// </param>
        /// <returns>
        /// The desired weather provider's endpoint from the application settings.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        Uri GetWeatherProviderUri(string? weatherProviderName = null);
    }
}
