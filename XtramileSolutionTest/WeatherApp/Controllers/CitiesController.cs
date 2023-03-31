using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly ICities _cities = new Cities();

        public CitiesController(ILogger<CitiesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string[] Get(string country)
        {
            return _cities.GetCitiesByCountry(country);
        }
    }
}