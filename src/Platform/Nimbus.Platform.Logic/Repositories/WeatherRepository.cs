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
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("OpenMeteoClient");
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

        public async Task<Weather?> GetWeatherResultAsync(double longitude, double latitude)
        {
            var openMeteoEndpoint = GetOpenMeteoQueryEndpoint(longitude, latitude);
            var results = await TryQueryAsync(openMeteoEndpoint);
            if (results == null)
            {
                _logger.LogError($"{nameof(GetWeatherResultAsync)}: Failed to get results from OpenMeteo endpoint \"{openMeteoEndpoint}\"");
                return default;
            }

            return _mapper.Map<OpenMeteoResponse, Weather>(results);
        }

        /// <summary>
        /// Gets an OpenMeteo query endpoint with the provided <paramref name="longitude"/> and <paramref name="latitude"/>
        /// attached as query strings.
        /// </summary>
        /// <param name="longitude">
        /// The longitude to retrieve the weather information for.
        /// </param>
        /// <param name="latitude">
        /// The latitude to retrieve the weather information for.
        /// </param>
        /// <returns>
        /// A <see cref="Uri"/> containing the <paramref name="longitude"/> and <paramref name="latitude"/>.
        /// </returns>
        private static Uri GetOpenMeteoQueryEndpoint(double longitude, double latitude)
        {
            var openMeteoUriBuilder = new UriBuilder("https://api.open-meteo.com/v1/forecast");
            var openMeteoQueryBuilder = HttpUtility.ParseQueryString(openMeteoUriBuilder.Query);
            openMeteoQueryBuilder["longitude"] = longitude.ToString();
            openMeteoQueryBuilder["latitude"] = latitude.ToString();
            openMeteoQueryBuilder["current"] = string.Join(",", _weatherResponseFields);
            openMeteoQueryBuilder["forecast_days"] = "1";
            openMeteoUriBuilder.Query = openMeteoQueryBuilder.ToString();

            return openMeteoUriBuilder.Uri;
        }

        /// <summary>
        /// Tries to query OpenMeteo using the provided <paramref name="openMeteoEndpoint"/>.
        /// </summary>
        /// <param name="openMeteoEndpoint">
        /// The endpoint to run an OpenMeteo query on.
        /// </param>
        /// <returns>
        /// An <see cref="OpenMeteoResponse"/>.
        /// </returns>
        private async Task<OpenMeteoResponse?> TryQueryAsync(Uri openMeteoEndpoint)
        {
            try
            {
                var results = await _httpClient.GetAsync(openMeteoEndpoint);
                return await results.Content.ReadFromJsonAsync<OpenMeteoResponse>();
            }
            catch
            {
                return default;
            }
        }
    }
}
