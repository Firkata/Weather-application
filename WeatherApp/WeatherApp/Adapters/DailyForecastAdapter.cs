using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using WeatherApp.Models;

namespace WeatherApp.Adapters
{
    public class DailyForecastViewHolder : Java.Lang.Object
    {
        public TextView Date { get; set; }
        public ImageView Image { get; set; }
        public TextView Degrees { get; set; }
    }

    public class DailyForecastAdapter : BaseAdapter
    {
        private Activity activity;
        private List<DailyForecastModel> dailyForecast;

        public DailyForecastAdapter(Activity activity, List<DailyForecastModel> dailyForecast)
        {
            this.activity = activity;
            this.dailyForecast = dailyForecast;
        }

        public override int Count
        {
            get
            {
                return dailyForecast.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return dailyForecast[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_daily_forecast, parent, false);

            var date = view.FindViewById<TextView>(Resource.Id.daily_forecast_date);
            var image = view.FindViewById<ImageView>(Resource.Id.daily_forecast_image);
            var degrees = view.FindViewById<TextView>(Resource.Id.daily_forecast_degrees);

            date.Text = dailyForecast[position].Date;
            image.SetImageResource(dailyForecast[position].ImageResource);
            degrees.Text = dailyForecast[position].Degrees;

            return view;
        }
    }
}