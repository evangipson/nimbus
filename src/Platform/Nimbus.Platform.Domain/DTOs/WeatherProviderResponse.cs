using System.Text.Json.Serialization;

namespace Nimbus.Platform.Domain.DTOs
{
    public class WeatherProviderResponse
    {
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double ResponseTime { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public int OffsetSeconds { get; set; }

        [JsonPropertyName("timezone")]
        public string? Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string? TimezoneShortName { get; set; }

        [JsonPropertyName("elevation")]
        public float Elevation { get; set; }

        [JsonPropertyName("current_units")]
        public WeatherProviderUnits? CurrentWeatherUnits { get; set; }

        [JsonPropertyName("current")]
        public WeatherProviderForecast? CurrentWeather { get; set; }
    }
}
