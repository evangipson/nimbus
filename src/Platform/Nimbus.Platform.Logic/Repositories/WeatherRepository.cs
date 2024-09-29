using System.Net.Http.Json;
using System.Web;
using Microsoft.Extensions.Logging;
using AutoMapper;

using Nimbus.Platform.Domain.DTOs;
using Nimbus.Platform.Domain.Models;

namespace Nimbus.Platform.Logic.Repositories
{
    /// <inheritdoc cref="IWeatherRepository"/>
    public class WeatherRepository(ILogger<WeatherRepository> logger, IHttpClientFactory httpClientFactory, IMapper mapper) : IWeatherRepository
    {
        private readonly ILogger<WeatherRepository> _logger = logger;
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("WeatherProviderClient");
        private readonly IMapper _mapper = mapper;

        private static readonly List<string> _weatherResponseFields =
        [
            "temperature_2m",
            "relative_humidity_2m",
            "is_day",
            "precipitation",
            "cloud_cover",
            "wind_speed_10m",
            "wind_direction_10m"
        ];

        public async Task<WeatherForecast> GetWeatherResultAsync(Uri weatherProviderUri, double longitude, double latitude)
        {
            var weatherProviderEndpoint = GetWeatherProviderQueryEndpoint(weatherProviderUri, longitude, latitude);
            var results = await TryQueryAsync(weatherProviderEndpoint);
            if (results == null)
            {
                throw new InvalidOperationException($"{nameof(GetWeatherResultAsync)}: Failed to get results from the weather provider endpoint: {weatherProviderEndpoint}");
            }

            return _mapper.Map<WeatherProviderResponse, WeatherForecast>(results);
        }

        /// <summary>
        /// Gets a query endpoint with the provided <paramref name="longitude"/> and <paramref name="latitude"/>
        /// attached as query strings.
        /// </summary>
        /// <param name="weatherProviderUri">
        /// The <see cref="Uri"/> of the weather provider.
        /// </param>
        /// <param name="longitude">
        /// The longitude to retrieve the weather information for.
        /// </param>
        /// <param name="latitude">
        /// The latitude to retrieve the weather information for.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the <paramref name="longitude"/> and <paramref name="latitude"/>.
        /// </returns>
        private static Uri GetWeatherProviderQueryEndpoint(Uri weatherProviderUri, double longitude, double latitude)
        {
            var weatherProviderUriBuilder = new UriBuilder(weatherProviderUri);
            var weatherProviderQueryBuilder = HttpUtility.ParseQueryString(weatherProviderUriBuilder.Query);
            weatherProviderQueryBuilder["longitude"] = longitude.ToString();
            weatherProviderQueryBuilder["latitude"] = latitude.ToString();
            weatherProviderQueryBuilder["current"] = string.Join(",", _weatherResponseFields);
            weatherProviderQueryBuilder["forecast_days"] = "1";
            weatherProviderQueryBuilder["temperature_unit"] = "fahrenheit";
            weatherProviderQueryBuilder["wind_speed_unit"] = "mph";
            weatherProviderQueryBuilder["precipitation_unit"] = "inch";
            weatherProviderUriBuilder.Query = weatherProviderQueryBuilder.ToString();

            return weatherProviderUriBuilder.Uri;
        }

        /// <summary>
        /// Tries to query the weather provider using the provided <paramref name="weatherProviderEndpoint"/>.
        /// </summary>
        /// <param name="weatherProviderEndpoint">
        /// The endpoint to run a weather query against.
        /// </param>
        /// <returns>
        /// An <see cref="WeatherProviderResponse"/>.
        /// </returns>
        private async Task<WeatherProviderResponse?> TryQueryAsync(Uri weatherProviderEndpoint)
        {
            try
            {
                var results = await _httpClient.GetAsync(weatherProviderEndpoint);
                return await results.Content.ReadFromJsonAsync<WeatherProviderResponse>();
            }
            catch
            {
                return default;
            }
        }
    }
}
