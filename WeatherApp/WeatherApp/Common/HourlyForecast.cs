using System;
using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Common
{
    public class HourlyForecast
    {
        public DateTime DateTime { get; set; }
        public int EpochDateTime { get; set; }
        public int WeatherIcon { get; set; }
        public string IconPhrase { get; set; }
        public bool IsDaylight { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
        public Wind Wind { get; set; }
        public int RelativeHumidity { get; set; }
        public int UVIndex { get; set; }
        public string UVIndexText { get; set; }
        public int PrecipitationProbability { get; set; }
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
        public int CloudCover { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
}