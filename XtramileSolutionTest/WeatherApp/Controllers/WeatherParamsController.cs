using System.Threading.Tasks;
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
        private readonly IWeatherParamsService _weatherParamsService;

        public WeatherParamsController(ILogger<WeatherParamsController> logger)
        {
            _logger = logger;
            _weatherParamsService = new WeatherParamsService();
        }

        [HttpGet]
        public Task<IWeatherParams> Get(string city)
        {
            return Task.FromResult(_weatherParamsService.RetrieveWeather(city));
        }
    }
}