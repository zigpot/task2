namespace WeatherApp.Models
{
    public interface ICities
    {
        public string[] GetCitiesByCountry(string country);
    }
}