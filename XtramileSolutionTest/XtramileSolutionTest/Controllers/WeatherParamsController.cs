using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XtramileSolutionTest.Models;
using XtramileSolutionTest.Services;

namespace XtramileSolutionTest.Controllers
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
            return WeatherParamsService.RetrieveWeather(city);
        }
    }
}