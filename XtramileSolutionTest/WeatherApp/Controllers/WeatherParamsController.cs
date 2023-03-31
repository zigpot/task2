using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherParamsController : ControllerBase
    {
        private readonly ILogger<WeatherParamsController> _logger;

        public WeatherParamsController(ILogger<WeatherParamsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IWeatherParams Get(string city)
        {
            IWeatherParamsService weatherParamsService = new WeatherParamsService();
            return weatherParamsService.RetrieveWeather(city);
        }
    }
}