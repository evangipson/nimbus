namespace Nimbus.Platform.Logic.Services
{
    /// <summary>
    /// A service responsible for interacting with the application settings.
    /// </summary>
    public interface IEnvironmentService
    {
        /// <summary>
        /// Gets the path for a database from the application settings.
        /// </summary>
        /// <param name="databaseName">
        /// The name of the database to get from the application settings.
        /// </param>
        /// <returns>
        /// The desired database's path from the application settings.
        /// </returns>
        string GetDatabase(string databaseName);
    }
}
