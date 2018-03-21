using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherTechnicalTest.Proxies.Interfaces;

namespace WeatherTechnicalTest.Controllers
{
    [Route("api")]
    public class WeatherController : Controller
    {
        private readonly IGlobalWeatherProxy _globalWeatherProxy;

        public WeatherController(IGlobalWeatherProxy globalWeatherProxy)
        {
            _globalWeatherProxy = globalWeatherProxy;
        }

        [HttpGet, Route("country/{country}/cities")]
        public async Task<IActionResult> GetCities(string country)
        {
            var cities = await _globalWeatherProxy.GetCitiesByCountry(country);
            return Ok(cities);
        }

        [HttpGet, Route("country/{country}/cities/weather/{city}")]
        public async Task<IActionResult> GetWeather(string country, string city)
        {
            var weather = await _globalWeatherProxy.GetWeatherByCountryAndCity(country, city);
            return Ok(weather);
        }
    }
}