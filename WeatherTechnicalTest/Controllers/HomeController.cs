using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherTechnicalTest.Proxies.Interfaces;

namespace WeatherTechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGlobalWeatherProxy _globalWeatherProxy;

        public HomeController(IGlobalWeatherProxy globalWeatherProxy)
        {
            _globalWeatherProxy = globalWeatherProxy;
        }
        public IActionResult Index()
        {
            var test = _globalWeatherProxy.GetCitiesByCountry("Australia");
            //var test = new GlobalWeather.GlobalWeatherSoapClient(new GlobalWeather.GlobalWeatherSoapClient.EndpointConfiguration());
            //var a = test.GetCitiesByCountryAsync("Australia").Result;
            ////var serializer = new XmlSerializer(typeof(@string));
            ////serializer.Deserialize(new MemoryStream()

            //XmlSerializer ser = new XmlSerializer(typeof(String));
            //using (TextReader reader = new StringReader(a))
            //{
            //    var result = (String)ser.Deserialize(reader);
            //}

            ////XmlSerializer ser = new XmlSerializer(typeof(NewDataSet));
            ////using (TextReader reader = new StringReader(a))
            ////{
            ////    var result = (NewDataSet)ser.Deserialize(reader);
            ////}
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}