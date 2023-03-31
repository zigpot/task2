using System;
using System.Globalization;
using XtramileSolutionTest.Models;

namespace XtramileSolutionTest.Services
{
    public class WeatherParamsService
    {
        public WeatherParamsService()
        {
            ;
        }

        private static readonly string[] SkyConditions = {
            "Clear", "Mostly Clear", "Partly Cloudy", "Mostly Cloudy", "Cloudy", "Fair"
        };

        private static string RetrieveSkyCondition(Random rng)
        {
            return SkyConditions[rng.Next(SkyConditions.Length)];
        }

        private static string RetrieveWind(Random rng)
        {
            return rng.Next(3, 24).ToString();
        }

        private static string RetrieveVisibility(Random rng)
        {
            return (rng.Next(770, 20000) / 1000.0).ToString(CultureInfo.InvariantCulture);
        }

        private static string RetrieveDewPoint(Random rng)
        {
            return rng.Next(55, 65).ToString();
        }

        private static string RetrieveRelativeHumidity(Random rng)
        {
            return rng.Next(0, 100).ToString();
        }

        private static string RetrievePressure(Random rng)
        {
            return (rng.Next(100000, 101325) / 100.0).ToString(CultureInfo.InvariantCulture);
        }

        private static DateTime RetrieveTime()
        {
            return DateTime.Now;
        }

        private static int RetrieveTemperatureC(Random rng)
        {
            return rng.Next(-20, 55);
        }

        public static IWeatherParams RetrieveWeather(string city)
        {
            int seed = (city + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond)).GetHashCode();
            Random rng = new Random(seed);
            WeatherParams returnWeatherParams =
                new WeatherParams
                {
                    Location = city,
                    SkyCondition = RetrieveSkyCondition(rng),
                    Wind = RetrieveWind(rng),
                    Visibility = RetrieveVisibility(rng),
                    DewPoint = RetrieveDewPoint(rng),
                    RelativeHumidity = RetrieveRelativeHumidity(rng),
                    Pressure = RetrievePressure(rng),
                    Time = RetrieveTime(),
                    TemperatureC = RetrieveTemperatureC(rng)
                };
            return returnWeatherParams;
        }
    }
}