using System.Text.Json.Serialization;

namespace Nimbus.Platform.Domain.DTOs
{
    public class OpenMeteoWeatherUnits
    {
        [JsonPropertyName("time")]
        public string? DateUnit { get; set; }

        [JsonPropertyName("interval")]
        public string? Interval { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string? TemperatureUnit { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public string? HumidityUnit { get; set; }

        [JsonPropertyName("precipitation")]
        public string? PrecipitationUnit { get; set; }

        [JsonPropertyName("cloud_cover")]
        public string? CloudCoverUnit { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public string? WindSpeedUnit { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        public string? WindDirectionUnit { get; set; }
    }
}
