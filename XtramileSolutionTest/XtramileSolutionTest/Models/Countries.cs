namespace XtramileSolutionTest.Models
{
    public class Countries : ICountries
    {
        private static readonly string[] _countriesList = {
            "Australia", "United States", "Indonesia", "Germany", "India", "Brazil"
        };

        public string[] GetCountriesList()
        {
            return _countriesList;
        }
        
    }
}