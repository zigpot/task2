using System.Collections.Generic;

namespace XtramileSolutionTest.Models
{
    public class Cities : ICities
    {
        private readonly Dictionary<string, string[]> _citiesList = new Dictionary<string, string[]>
        {
            {"Australia", new[] {"Melbourne", "Perth", "Sidney"}},
            {"United States", new[] {"New York", "San Francisco", "Seattle", "Los Angeles"}},
            {"Indonesia", new[] {"Jakarta", "Medan", "Bandung"}},
            {"Germany", new[] {"Berlin", "Frankfurt"}},
            {"India", new[] {"Mumbail", "Kolkatta"}},
            {"Brazil", new[] {"Rio de Jainero", "Sao Paolo"}}
        };

        public string[] GetCitiesByCountry(string country)
        {
            return _citiesList.ContainsKey(country) ? _citiesList[country] : new[] {""};
        }
    }
}