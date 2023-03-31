using System;

namespace XtramileSolutionTest.Models
{
    public class WeatherParams : IWeatherParams
    {
        public string Location { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyCondition { get; set; }
        public string DewPoint  { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
        public DateTime Time { get; set; }
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
    }
}