using System.Text.Json.Serialization;

namespace Nimbus.Platform.Domain.DTOs
{
    public class WeatherProviderForecast
    {
        [JsonPropertyName("time")]
        public DateTime Date { get; set; }

        [JsonPropertyName("temperature_2m")]
        public float Temperature { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public float Humidity { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("precipitation")]
        public float PrecipitationChance { get; set; }

        [JsonPropertyName("cloud_cover")]
        public float CloudCover { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public float WindSpeed { get; set; }

        [JsonPropertyName("wind_direction_10m")]
        public float WindDirection { get; set; }
    }
}
