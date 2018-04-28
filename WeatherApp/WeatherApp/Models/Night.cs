namespace WeatherApp.Models
{
    public class Night
    {
        public string IconPhrase { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public int PrecipitationProbability { get; set; }
        public int ThunderstormProbability { get; set; }
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
        public double HoursOfPrecipitation { get; set; }
        public double HoursOfRain { get; set; }
        public double HoursOfSnow { get; set; }
        public double HoursOfIce { get; set; }
        public int CloudCover { get; set; }
    }
}