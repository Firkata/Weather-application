namespace WeatherApp.Models
{
    public class HourlyForecastModel
    {
        public int Id { get; set; }
        public string Hour { get; set; }
        public int ImageResource { get; set; }
        public string Degrees { get; set; }
    }
}