using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using WeatherApp.Models;
using WeatherApp.Adapters;
using WeatherApp.Common;
using System.Globalization;
using Android.Support.V7.Widget;
using WeatherApp.Views;
using Android.Views.Animations;
using Android.Content;
using WeatherApp.Custom;
using Android.Animation;
using Android.Views;
using System.Text.RegularExpressions;
using Android.Graphics;

namespace WeatherApp
{
    [Activity(Label = "WeatherApp", Theme = "@style/AppTheme")]//, MainLauncher = true
    public class MainActivity : Activity
    {
        TextView currentTemp;
        TextView minTemp;
        TextView maxTemp;
        TextView weatherPhrase;
        TextView percentageIncrease;
        ImageView windmillBigTop;
        ImageView windmillBigBottom;
        ImageView windmillSmallTop;
        ImageView windmillSmallBottom;
        RelativeLayout mainLayout;
        NotScrollableGridView dailyForecastList;
        RecyclerView hourlyForecastList;
        RecyclerView.LayoutManager hfLayoutManager;
        HourlyForecastCollection hfCollection;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //ActionBar.Hide();
            DataExtractor extractor = new DataExtractor();
            var halfDayForecast = extractor.HalfDayForecast();
            var fiveDaysForecast = extractor.FiveDayForecast();
            windmillBigTop = FindViewById<ImageView>(Resource.Id.windmill_big_top);
            windmillBigBottom = FindViewById<ImageView>(Resource.Id.windmill_big_bottom);
            windmillSmallTop = FindViewById<ImageView>(Resource.Id.windmill_small_top);
            windmillSmallBottom = FindViewById<ImageView>(Resource.Id.windmill_small_bottom);
            hfCollection = new HourlyForecastCollection(HalfDayForecast(halfDayForecast));
            currentTemp = FindViewById<TextView>(Resource.Id.current_temp);
            minTemp = FindViewById<TextView>(Resource.Id.min_temp);
            maxTemp = FindViewById<TextView>(Resource.Id.max_temp);
            weatherPhrase = FindViewById<TextView>(Resource.Id.weather_phrase);
            mainLayout = FindViewById<RelativeLayout>(Resource.Id.main_layout);
            dailyForecastList = FindViewById<NotScrollableGridView>(Resource.Id.daily_forecast_list);
            hourlyForecastList = FindViewById<RecyclerView>(Resource.Id.hourly_forecast_list);
            hfLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Horizontal, false);
            hourlyForecastList.SetLayoutManager(hfLayoutManager);
            hourlyForecastList.SetAdapter(new HourlyAdapter(hfCollection));
            dailyForecastList.Adapter = new DailyForecastAdapter(this, FiveDayForecast(fiveDaysForecast));

            windmillBigTop.SetImageResource(Resource.Drawable.windmill_top);
            windmillBigBottom.SetImageResource(Resource.Drawable.windmill_bottom);
            windmillSmallTop.SetImageResource(Resource.Drawable.windmill_top);
            windmillSmallBottom.SetImageResource(Resource.Drawable.windmill_bottom);

            currentTemp.Text = " " + Math.Round(halfDayForecast[0].Temperature.Value) + "\u00B0";
            maxTemp.Text = Math.Round(halfDayForecast[0].RealFeelTemperature.Value) + "\u00B0";
            minTemp.Text = "/" + Math.Round(halfDayForecast[0].DewPoint.Value) + "\u00B0";
            weatherPhrase.Text = halfDayForecast[0].IconPhrase;

            var animation = AnimationUtils.LoadAnimation(Android.App.Application.Context, Resource.Animation.rotate_animation);
            animation.Duration = 4000;
            windmillBigTop.StartAnimation(animation);
            var animation2 = AnimationUtils.LoadAnimation(Android.App.Application.Context, Resource.Animation.rotate_animation_2);
            animation2.Duration = 4000;
            windmillSmallTop.StartAnimation(animation2);

            //var humidityPercentage = fiveDaysForecast.DailyForecasts[0].AirAndPollen.Value;
            //var circleDegrees = Convert.ToInt32(3.6 * humidityPercentage);

            Circle circle = FindViewById<Circle>(Resource.Id.humidity_circle);

            CircleAngleAnimation circleAnimation = new CircleAngleAnimation(circle, 300);
            circleAnimation.Duration = 4000;
            circle.StartAnimation(circleAnimation);

            
            percentageIncrease = FindViewById<TextView>(Resource.Id.humidity_number);
            StartCountAnimation(82);

            dailyForecastList.Touch += (o, e) =>
            {
                circle.StartAnimation(circleAnimation);
            };

            mainLayout.Touch += (o, e) =>
            {
                circle.StartAnimation(circleAnimation);
            };

            circle.Touch += (o, e) =>
            {
                circle.StartAnimation(circleAnimation);
                StartCountAnimation(82);
            };


            SetBackgroundImage();
        }

        private void StartCountAnimation(int humidityPercentage)
        {
            ValueAnimator animator = ValueAnimator.OfInt(0, humidityPercentage);
            animator.SetDuration(4000);
            animator.Start();
            animator.Update += (object sender, ValueAnimator.AnimatorUpdateEventArgs e) =>
            {
                int newValue = (int)e.Animation.AnimatedValue;
                percentageIncrease.Text = Convert.ToString(newValue) + "%";
            };
        }

        private int ImagePicker(string phrase, int hour = 12)
        {
            if (Regex.IsMatch(phrase, @"\b(mostly|partly|sunny)\b", RegexOptions.IgnoreCase))
            {
                return Resource.Drawable.sunny;
            }
            else if(Regex.IsMatch(phrase, @"\b(mostly|partly|cloudy)\b", RegexOptions.IgnoreCase))
            {
                if(hour>6 && hour<19)
                    return Resource.Drawable.sunclouds;
                else
                    return Resource.Drawable.cloudnight;
            }
            else if(Regex.IsMatch(phrase, @"\b(intermittent|clouds)\b", RegexOptions.IgnoreCase))
            {
                if (hour > 6 && hour < 19)
                    return Resource.Drawable.clouds;
                else
                    return Resource.Drawable.cloudnight;
            }
            else if (Regex.IsMatch(phrase, @"\b(storm|thunderstorm)\b", RegexOptions.IgnoreCase))
            {
                return Resource.Drawable.storm;
            }
            else if (Regex.IsMatch(phrase, @"\b(rain|rainy)\b", RegexOptions.IgnoreCase))
            {
                if (hour > 6 && hour < 19)
                    return Resource.Drawable.rain;
                else
                    return Resource.Drawable.nightrain;
            }
            else if (Regex.IsMatch(phrase, @"\b(snow|snowy)\b", RegexOptions.IgnoreCase))
            {
                return Resource.Drawable.snow;
            }
            else if (Regex.IsMatch(phrase, @"\b(clear)\b", RegexOptions.IgnoreCase))
            {
                if (hour > 6 && hour < 19)
                    return Resource.Drawable.sunny;
                else
                    return Resource.Drawable.clearnight;
            }
            else
            {
                if (hour > 6 && hour < 19)
                    return Resource.Drawable.sunny;
                else
                    return Resource.Drawable.clearnight;
            }

        }

        private List<HourlyForecastModel> HalfDayForecast(List<HourlyForecast> halfDayForecast)
        {
            List<HourlyForecastModel> list = new List<HourlyForecastModel>();
            for (int i = 0; i < 11; i++)
            {
                HourlyForecastModel hourlyForecast = new HourlyForecastModel();

                hourlyForecast.Id = i;
                hourlyForecast.Hour = halfDayForecast[i].DateTime.Hour + ":00";
                hourlyForecast.ImageResource = ImagePicker(halfDayForecast[i].IconPhrase, halfDayForecast[i].DateTime.Hour);
                hourlyForecast.Degrees = string.Format("{0}{1}", Math.Round(halfDayForecast[i].Temperature.Value).ToString(),"\u00B0");

                list.Add(hourlyForecast);
            }
            return list;
        }

        private List<DailyForecastModel> FiveDayForecast(DailyForecast fiveDaysForecast)
        {
            List<DailyForecastModel> list = new List<DailyForecastModel>();

            for (int i = 1; i < 5; i++)
            {
                DailyForecastModel dailyForecast = new DailyForecastModel();

                dailyForecast.Id = i;
                if (i == 1)
                {
                    dailyForecast.Date = string.Format("Tomorrow, {0} {1}",
                        fiveDaysForecast.DailyForecasts[i].Date.Date.Day,
                        CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fiveDaysForecast.DailyForecasts[i].Date.Date.Month));
                }
                else
                {
                    dailyForecast.Date = string.Format("{0}, {1} {2}",
                    fiveDaysForecast.DailyForecasts[i].Date.Date.DayOfWeek,
                    fiveDaysForecast.DailyForecasts[i].Date.Date.Day,
                    CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(fiveDaysForecast.DailyForecasts[i].Date.Date.Month));
                }

                dailyForecast.ImageResource = ImagePicker(fiveDaysForecast.DailyForecasts[i].Day.LongPhrase);
                dailyForecast.DegreesMin = "/" + Math.Ceiling(fiveDaysForecast.DailyForecasts[i].Temperature.Minimum.Value) + "\u00B0";
                dailyForecast.Degrees = Math.Ceiling(fiveDaysForecast.DailyForecasts[i].Temperature.Maximum.Value) + "\u00B0";

                list.Add(dailyForecast);
            };

            return list;
        }

        void SetBackgroundImage()
        {
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 19)
            {
                mainLayout.SetBackgroundResource(Resource.Drawable.sunny_sky);
            }
            else
            {
                mainLayout.SetBackgroundResource(Resource.Drawable.night);
            }
            mainLayout.SetBackgroundResource(Resource.Drawable.night);
        }
    }
}

