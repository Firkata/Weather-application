using System;
using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Common
{
    public class OneDayForecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Sun Sun { get; set; }
        public Moon Moon { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
        public double HoursOfSun { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class DailyForecast
    {
        public List<OneDayForecast> DailyForecasts { get; set; }
    }
}