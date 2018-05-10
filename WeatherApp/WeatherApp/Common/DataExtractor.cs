using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherApp.Common
{
    public class DataExtractor
    {
        string url = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/51097?apikey=rFWA73QrdD2XsYSRD8uT7wc2xSFRUsNk&details=true&metric=true";
        string url2 = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/51097?apikey=rFWA73QrdD2XsYSRD8uT7wc2xSFRUsNk&details=true&metric=true";

        public DailyForecast FiveDayForecast()
        {
            string json = string.Empty;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }
            var a = JsonConvert.DeserializeObject<DailyForecast>(json);
            return a;
        }

        public List<HourlyForecast> HalfDayForecast()
        {
            string json = string.Empty;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url2);
            }

            var a = JsonConvert.DeserializeObject<List<HourlyForecast>>(json);
            return a;
        }
    }
}