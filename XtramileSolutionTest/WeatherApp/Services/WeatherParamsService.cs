using System;
using System.Globalization;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherParamsService : IWeatherParamsService
    {
        public int ConvertCToF(int temperatureC)
        {
            return 32 + (int) (temperatureC / 0.5556);
        }

        public int ConvertFToC(int temperatureC)
        {
            return (int) ((temperatureC - 32) * 0.5556);
        }

        public WeatherParamsService()
        {
            ;
        }

        private static readonly string[] SkyConditions =
        {
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

        public IWeatherParams RetrieveWeather(string city)
        {
            int seed = (city + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond)).GetHashCode();
            Random rng = new Random(seed);

            string skyCondition = RetrieveSkyCondition(rng);
            string wind = RetrieveWind(rng);
            string visibility = RetrieveVisibility(rng);
            string dewPoint = RetrieveDewPoint(rng);
            string relativeHumidity = RetrieveRelativeHumidity(rng);
            string pressure = RetrievePressure(rng);
            DateTime time = RetrieveTime();
            int temperatureC = RetrieveTemperatureC(rng);
            int temperatureF = ConvertCToF(temperatureC);
            WeatherParams returnWeatherParams =
                new WeatherParams(
                    city,
                    skyCondition,
                    wind,
                    visibility,
                    dewPoint,
                    relativeHumidity,
                    pressure,
                    time,
                    temperatureC,
                    temperatureF
                );
            return returnWeatherParams;
        }
    }

    public interface IWeatherParamsService
    {
        public int ConvertCToF(int temperatureC);

        public int ConvertFToC(int temperatureC);

        public IWeatherParams RetrieveWeather(string city);
    }
}