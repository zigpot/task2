using System.Collections.Generic;

namespace XtramileSolutionTest.Models
{
    public interface ICities
    {
        public string[] GetCitiesByCountry(string country);
    }
}