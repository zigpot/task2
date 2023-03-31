using System.Threading.Tasks;
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
        private readonly ICities _cities;

        public CitiesController(ILogger<CitiesController> logger)
        {
            _logger = logger;
            _cities = new Cities();
        }

        [HttpGet]
        public Task<string[]> Get(string country)
        {
            return Task.FromResult(_cities.GetCitiesByCountry(country));
        }
    }
}