using System;

namespace AccountsPayable
{
    public class WeatherReport
    {
        private readonly IWeatherService svc;

        public WeatherReport(IWeatherService weatherSvc)
        {
            svc = weatherSvc;
        }

        public int GetWeatherReport(string locationZip)
        {
            svc.ZipCode = locationZip;
            return svc.GetCurrentTemp();
        }
    }
}