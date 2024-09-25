using Microsoft.AspNetCore.Mvc;

using Nimbus.Platform.Logic.Managers;

namespace Nimbus.View.Api.Controllers
{
    [ApiController]
    [Route("/weather")]
    public class WeatherController(ILogger<WeatherController> logger, IWeatherManager weatherManager) : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger = logger;
        private readonly IWeatherManager _weatherManager = weatherManager;

        [HttpGet]
        public Task<string> GetCurrentWeather() => _weatherManager.GetCurrentWeatherAsync();
    }
}
