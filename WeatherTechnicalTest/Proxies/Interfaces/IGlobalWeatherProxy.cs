using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherTechnicalTest.Proxies.Interfaces
{
    public interface IGlobalWeatherProxy
    {
        Task<IReadOnlyList<string>> GetCitiesByCountry(string country);

        Task<IReadOnlyList<string>> GetWeatherByCountryAndCity(string country, string city);
    }
}
