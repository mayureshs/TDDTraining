namespace AccountsPayable
{
    public class WeatherService : IWeatherService
    {
        public virtual string ZipCode { get; set; }

        public string CityName { get; set; }

        public virtual int GetCurrentTemp()
        {
            return 12345;
        }
    }
}