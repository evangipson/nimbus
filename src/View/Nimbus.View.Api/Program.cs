using Nimbus.View.Api.Extensions;

namespace Nimbus.View.Api
{
    /// <summary>
    /// A class which is referenced when the application starts.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Configures and runs the application.
        /// </summary>
        /// <param name="args">
        /// A list of string arguments for application initialization.
        /// </param>
        internal static void Main(string[] args) => WebApplication.CreateBuilder(args)
            .ConfigureBuilder()
            .Build()
            .ConfigureApplication()
            .Run();
    }
}
