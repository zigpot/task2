using System;
using System.Linq;
using NUnit.Framework;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Test
{
    public class Tests
    {
        private readonly Countries _countries;
        private readonly Cities _cities;
        private readonly IWeatherParamsService _weatherParamsService;

        private readonly int[] _tempsInC =
        {
            7, 5, -17, 29, -13, 31, -6, 3
        };

        private readonly int[] _tempsInF =
        {
            44, 40, 2, 84, 9, 87, 22, 37
        };


        public Tests()
        {
            _weatherParamsService = new WeatherParamsService();
            _countries = new Countries();
            _cities = new Cities();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMeta()
        {
            Assert.Pass();
        }

        [TestCase("Jakarta")]
        [TestCase("Medan")]
        public void TestModelCitiesIndonesiaCorrect(string city)
        {
            Assert.IsTrue((_cities.GetCitiesByCountry("Indonesia")).Any(city.Contains));
        }

        [TestCase("Sao Paolo")]
        [TestCase("Frankfurt")]
        public void TestModelCitiesIndonesiaIncorrect(string city)
        {
            Assert.IsFalse((_cities.GetCitiesByCountry("Indonesia")).Any(city.Contains));
        }

        [TestCase("Melbourne")]
        [TestCase("Perth")]
        public void TestModelCitiesAustralia(string city)
        {
            Assert.IsTrue((_cities.GetCitiesByCountry("Australia")).Any(city.Contains));
        }

        [TestCase("Indonesia")]
        [TestCase("United States")]
        [TestCase("Australia")]
        [TestCase("India")]
        [TestCase("Brazil")]
        [TestCase("Germany")]
        public void TestModelCountries(string country)
        {
            Assert.IsTrue((_countries.GetCountriesList()).Any(country.Contains));
        }

        [TestCase("Canada")]
        [TestCase("Japan")]
        [TestCase("South Korea")]
        [TestCase("United Kingdom")]
        [TestCase("Singapore")]
        [TestCase("Mexico")]
        public void TestModelCountriesIncorrect(string country)
        {
            Assert.IsFalse((_countries.GetCountriesList()).Any(country.Contains));
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void TestModelWeatherParamsServiceCToFConverter(int index)
        {
            Assert.AreEqual(_weatherParamsService.ConvertCToF(_tempsInC[index]), _tempsInF[index]);
        }
        
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(6)]
        public void TestModelWeatherParamsServiceFToCConverter(int index)
        {
            Assert.AreNotEqual(_weatherParamsService.ConvertFToC(_tempsInC[index]), _tempsInF[index]);
        }
    }
}