using System.Text.RegularExpressions;

namespace WeatherApp.Helper
{
    public static class ImageHelper
    {
        public static int ImagePicker(string phrase, int hour = 12)
        {
            if (hour > 6 && hour < 20)
            {
                if (Regex.IsMatch(phrase, @"\b(mostly|partly|sunny)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.sunny;
                else if (Regex.IsMatch(phrase, @"\b(mostly|partly|cloudy)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.sunclouds;
                else if (Regex.IsMatch(phrase, @"\b(intermittent|clouds)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.clouds;
                else if (Regex.IsMatch(phrase, @"\b(storm|thunderstorm)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.storm;
                else if (Regex.IsMatch(phrase, @"\b(rain|rainy)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.rain;
                else if (Regex.IsMatch(phrase, @"\b(snow|snowy)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.snow;
                else if (Regex.IsMatch(phrase, @"\b(clear)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.sunny;
                else
                    return Resource.Drawable.sunny;
            }
            else
            {
                if (Regex.IsMatch(phrase, @"\b(mostly|partly|sunny)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.clearnight;
                else if (Regex.IsMatch(phrase, @"\b(mostly|partly|cloudy)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.cloudnight;
                else if (Regex.IsMatch(phrase, @"\b(intermittent|clouds)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.cloudnight;
                else if (Regex.IsMatch(phrase, @"\b(storm|thunderstorm)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.storm;
                else if (Regex.IsMatch(phrase, @"\b(rain|rainy)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.nightrain;
                else if (Regex.IsMatch(phrase, @"\b(snow|snowy)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.snow;
                else if (Regex.IsMatch(phrase, @"\b(clear)\b", RegexOptions.IgnoreCase))
                    return Resource.Drawable.clearnight;
                else
                    return Resource.Drawable.clearnight;
            }
        }
    }
}