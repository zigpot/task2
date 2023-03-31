using System;

namespace WeatherApp.Models
{
    public class WeatherParams : IWeatherParams
    {
        public WeatherParams(
            string _location,
            string _wind,
            string _visibility,
            string _skyCondition,
            string _dewPoint,
            string _relativeHumidity,
            string _pressure,
            DateTime _time,
            int _temperatureC,
            int _temperatureF)
        {
            Location = _location;
            Wind = _wind;
            Visibility = _visibility;
            SkyCondition = _skyCondition;
            DewPoint = _dewPoint;
            RelativeHumidity = _relativeHumidity;
            Pressure = _pressure;
            Time = _time;
            TemperatureC = _temperatureC;
            TemperatureF = _temperatureF;
        }

        public string Location { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyCondition { get; set; }
        public string DewPoint  { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
        public DateTime Time { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
    }
}