using System.Net.Http.Headers;

using Nimbus.Platform.Domain.Options;
using Nimbus.Platform.Logic.Managers;
using Nimbus.Platform.Logic.Mappings;
using Nimbus.Platform.Logic.Providers;
using Nimbus.Platform.Logic.Repositories;
using Nimbus.Platform.Logic.Services;

namespace Nimbus.View.Api.Extensions
{
    /// <summary>
    /// A collection of extensions for configuring a <see cref="WebApplication"/>.
    /// </summary>
    internal static class WebApplicationExtensions
    {
        /// <summary>
        /// Adds configuration options, dependency-injected services, controllers,
        /// and http client configuration to the application builder.
        /// </summary>
        /// <param name="builder">
        /// The builder for the application.
        /// </param>
        /// <returns>
        /// The provided <paramref name="builder"/> with all the configurations implemented.
        /// </returns>
        internal static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
        {
            builder.AddConfigurationOptions();
            builder.AddServices();
            builder.Services.AddControllers();
            builder.Services.AddHttpClient("OpenMeteoClient", client =>
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return builder;
        }

        /// <summary>
        /// Maps routes, adds swagger, and adds https to the application.
        /// </summary>
        /// <param name="webApplication">
        /// The built web application to configure.
        /// </param>
        /// <returns>
        /// The provided <paramref name="webApplication"/> with all the configurations implemented.
        /// </returns>
        internal static WebApplication ConfigureApplication(this WebApplication webApplication)
        {
            webApplication.MapControllers();
            webApplication.AddSwagger();
            webApplication.AddHttps();

            return webApplication;
        }

        /// <summary>
        /// Adds options to the application configuration, which provides
        /// access to the application settings without needing to inject
        /// an entire <see cref="IConfiguration"/>.
        /// </summary>
        /// <param name="builder">
        /// The builder for the application.
        /// </param>
        private static void AddConfigurationOptions(this WebApplicationBuilder builder)
        {
            _ = builder.Services.AddOptions<Databases>()
                .Bind(builder.Configuration.GetSection(nameof(Databases)));
        }

        /// <summary>
        /// Adds AutoMapper, Swagger, and dependency-injected services with
        /// their scope to the application builder services container.
        /// </summary>
        /// <param name="builder">
        /// The builder for the application.
        /// </param>
        private static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAutoMapper(mapperConfig => mapperConfig.AddMaps(typeof(WeatherMappingProfile)))
                .AddHttpContextAccessor()
                .AddTransient<IIpAddressProvider, IpAddressProvider>()
                .AddScoped<IGeolocationProvider, GeolocationProvider>()
                .AddScoped<IEnvironmentService, EnvironmentService>()
                .AddScoped<IWeatherRepository, WeatherRepository>()
                .AddScoped<IWeatherManager, WeatherManager>()
                .AddSwagger();
        }

        /// <summary>
        /// Adds Swagger to the provided <paramref name="services"/>.
        /// </summary>
        /// <param name="services">
        /// The <see cref="IServiceCollection"/> to add Swagger in.
        /// </param>
        /// <returns>
        /// The provided <paramref name="services"/> with Swagger added
        /// to the collection.
        /// </returns>
        private static IServiceCollection AddSwagger(this IServiceCollection services) => services.AddEndpointsApiExplorer().AddSwaggerGen();

        /// <summary>
        /// Adds Swagger to the provided <paramref name="webApplication"/>.
        /// </summary>
        /// <param name="webApplication">
        /// The <see cref="WebApplication"/> to add Swagger to.
        /// </param>
        /// <returns>
        /// The provided <paramref name="webApplication"/> with Swagger added.
        /// </returns>
        private static void AddSwagger(this WebApplication webApplication)
        {
            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }
        }

        /// <summary>
        /// Adds https to the provided <paramref name="webApplication"/>.
        /// </summary>
        /// <param name="webApplication">
        /// The <see cref="WebApplication"/> to add https to.
        /// </param>
        private static void AddHttps(this WebApplication webApplication)
        {
            webApplication.UseHttpsRedirection();
            webApplication.UseAuthorization();
        }
    }
}
