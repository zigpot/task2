using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private Countries _countries;

        private readonly ILogger<CountriesController> _logger;

        public CountriesController(ILogger<CountriesController> logger)
        {
            _logger = logger;
            _countries =  new Countries();
        }

        [HttpGet]
        public string[] Get()
        {
            return _countries.GetCountriesList();
        }
    }
}