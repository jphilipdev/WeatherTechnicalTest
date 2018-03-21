using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WeatherTechnicalTest.Proxies.Interfaces;

namespace WeatherTechnicalTest.Proxies
{
    public class GlobalWeatherProxy : IGlobalWeatherProxy
    {
        private static HttpClient HttpClient = new HttpClient();

        public GlobalWeatherProxy(IConfiguration configuration)
        {
            var baseUrl = configuration.GetValue<string>("EndPoints:GlobalWeather");
            HttpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<IReadOnlyList<string>> GetCitiesByCountry(string country)
        {
            var cities = HttpClient.GetAsync("globalweather.asmx/GetCitiesByCountry?CountryName=Australia").Result;
            var responseBody = await cities.Content.ReadAsStringAsync();
            var test2 = WebUtility.HtmlDecode(responseBody);
            XmlSerializer ser = new XmlSerializer(typeof(Models.String));
            using (TextReader reader = new StringReader(test2))
            {
                var result = (Models.String)ser.Deserialize(reader);

                return result.NewDataSet.Table.Select(p => p.City).ToList();
            }
        }
    }
}
