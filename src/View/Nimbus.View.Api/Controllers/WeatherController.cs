using Microsoft.AspNetCore.Mvc;

using Nimbus.Platform.Domain.Models;
using Nimbus.Platform.Logic.Managers;

namespace Nimbus.View.Api.Controllers
{
    [ApiController]
    [Route("/weather")]
    public class WeatherController(IWeatherManager weatherManager) : ControllerBase
    {
        /// <summary>
        /// Gets the current local weather.
        /// </summary>
        /// <returns>
        /// The current local weather.
        /// </returns>
        /// <remarks>
        /// Sample api request:
        /// 
        /// GET
        ///     /weather
        ///
        /// </remarks>
        [HttpGet]
        [Produces("application/json")]
        public Task<WeatherForecast> GetCurrentWeather() => weatherManager.GetCurrentWeatherAsync();
    }
}
