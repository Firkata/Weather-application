namespace WeatherApp.Models
{
    public class DailyForecastModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int ImageResource { get; set; }
        public string Degrees { get; set; }
        public string DegreesMin { get; set; }
    }
}