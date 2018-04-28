using System;

namespace WeatherApp.Models
{
    public class Sun
    {
        public DateTime Rise { get; set; }
        public int EpochRise { get; set; }
        public DateTime Set { get; set; }
        public int EpochSet { get; set; }
    }
}