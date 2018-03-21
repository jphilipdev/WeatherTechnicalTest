using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherTechnicalTest.Controllers;
using WeatherTechnicalTest.Models;
using WeatherTechnicalTest.Proxies.Interfaces;

namespace WeatherTechnicalTest.Tests
{
    [TestClass]
    public class WeatherControllerTests
    {
        private Mock<IGlobalWeatherProxy> _globalWeatherProxy;
        private WeatherController _subject;

        [TestInitialize]
        public void Setup()
        {
            _globalWeatherProxy = new Mock<IGlobalWeatherProxy>();
            _subject = new WeatherController(_globalWeatherProxy.Object);
        }

        [TestMethod]
        public async Task GivenCountryName_WhenCitiesAreRequested_ThenCitiesAreReturned()
        {
            // ARRANGE
            var country = "Country";
            var city1 = "City 1";
            var city2 = "City 2";
            var cities = new List<string>() { city1, city2 };

            _globalWeatherProxy.Setup(p => p.GetCitiesByCountry(country))
                               .Returns(Task.FromResult<IReadOnlyList<string>>(cities));

            // ACT
            var result = await _subject.GetCities(country);

            // ASSERT
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            var resultValue = ((OkObjectResult)result).Value as IReadOnlyList<string>;
            Assert.AreEqual(2, resultValue.Count);
            Assert.IsTrue(resultValue.Any(p => p == city1));
            Assert.IsTrue(resultValue.Any(p => p == city2));
        }

        [TestMethod]
        public async Task GivenCountryName_AndCityName_WhenWeatherIsRequested_ThenWeatherIsReturned()
        {
            // ARRANGE
            var country = "Country";
            var city = "City";
            var location = "Location";
            var time = new DateTime(2018, 01, 01);
            var wind = "Wind";
            var visibility = "Visibility";
            var skyConditions = "Sky Conditions";
            var temperature = 1.1;
            var dewPoint = 2.2;
            var relativeHumidity = 3.3;
            var pressure = 4.4;

            _globalWeatherProxy.Setup(p => p.GetWeatherByCountryAndCity(country, city))
                               .Returns(Task.FromResult(new Weather(location, time, wind, visibility, skyConditions, temperature, dewPoint, relativeHumidity, pressure)));

            // ACT
            var result = await _subject.GetWeather(country, city);

            // ASSERT
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            var resultValue = ((OkObjectResult)result).Value as Weather;
            Assert.AreEqual(location, resultValue.Location);
            Assert.AreEqual(time, resultValue.Time);
            Assert.AreEqual(wind, resultValue.Wind);
            Assert.AreEqual(visibility, resultValue.Visibility);
            Assert.AreEqual(skyConditions, resultValue.SkyConditions);
            Assert.AreEqual(temperature, resultValue.Temperature);
            Assert.AreEqual(dewPoint, resultValue.DewPoint);
            Assert.AreEqual(relativeHumidity, resultValue.RelativeHumidity);
            Assert.AreEqual(pressure, resultValue.Pressure);
        }
    }
}
