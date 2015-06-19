namespace AccountsPayable
{
    public interface IWeatherService
    {
        string ZipCode { get; set; }
        string CityName { get; set; }
        int GetCurrentTemp(); 
    }
}