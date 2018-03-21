using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherTechnicalTest.Models;

namespace WeatherTechnicalTest.Proxies.Interfaces
{
    public interface IGlobalWeatherProxy
    {
        Task<IReadOnlyList<string>> GetCitiesByCountry(string country);

        Task<Weather> GetWeatherByCountryAndCity(string country, string city);
    }
}
