using System;

namespace WeatherTechnicalTest.Models
{
    public class Weather
    {
        public Weather(string location, DateTime time, string wind, string visibility, string skyConditions, double temperature, double dewPoint, double relativeHumidity, double pressure)
        {
            Location = location;
            Time = time;
            Wind = wind;
            Visibility = visibility;
            SkyConditions = skyConditions;
            Temperature = temperature;
            DewPoint = dewPoint;
            RelativeHumidity = relativeHumidity;
            Pressure = pressure;
        }

        public string Location { get; }
        public DateTime Time { get; }
        public string Wind { get; }
        public string Visibility { get; }
        public string SkyConditions { get; }
        public double Temperature { get; }
        public double DewPoint { get; }
        public double RelativeHumidity { get; }
        public double Pressure { get; }
    }
}