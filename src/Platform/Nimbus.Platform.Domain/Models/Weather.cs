namespace Nimbus.Platform.Domain.Models
{
    public class Weather
    {
        public DateTime Date { get; set; }

        public string? DateUnit { get; set; }

        public bool IsDay { get; set; }

        public float Temperature { get; set; }

        public string? TemperatureUnit { get; set; }

        public float Humidity { get; set; }

        public string? HumidityUnit { get; set; }

        public float PrecipitationChance { get; set; }

        public string? PrecipitationUnit { get; set; }

        public float CloudCover { get; set; }

        public string? CloudCoverUnit { get; set; }

        public float WindSpeed { get; set; }

        public string? WindSpeedUnit { get; set; }

        public float WindDirection { get; set; }

        public string? WindDirectionUnit { get; set; }
    }
}
