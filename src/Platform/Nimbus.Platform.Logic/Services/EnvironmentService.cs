using Microsoft.Extensions.Options;

using Nimbus.Platform.Domain.Options;

namespace Nimbus.Platform.Logic.Services
{
    /// <inheritdoc cref="IEnvironmentService"/>
    public class EnvironmentService(IOptions<Databases> options) : IEnvironmentService
    {
        private readonly IOptions<Databases> _options = options;

        public string GetDatabase(string databaseName)
        {
            if(!IsValidDatabaseName(databaseName))
            {
                throw new InvalidOperationException($"Failed to find \"{databaseName}\" database. Make sure it's defined in the application settings.");
            }

            return _options.Value[databaseName];
        }

        /// <summary>
        /// Validates a database name from the application settings.
        /// </summary>
        /// <param name="databaseName">
        /// The name of the database to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the database is defined in the application settings,
        /// <c>false</c> otherwise.
        /// </returns>
        private bool IsValidDatabaseName(string databaseName)
        {
            if(string.IsNullOrEmpty(databaseName))
            {
                return false;
            }

            return _options.Value.ContainsKey(databaseName);
        }
    }
}
