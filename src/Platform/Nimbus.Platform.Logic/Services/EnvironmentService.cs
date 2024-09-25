using Microsoft.Extensions.Options;

using Nimbus.Platform.Domain.Options;

namespace Nimbus.Platform.Logic.Services
{
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
