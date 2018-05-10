using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using WeatherApp.Models;
using Android.Support.V7.Widget;

namespace WeatherApp.Adapters
{
    public class HourlyForecastCollection
    {
        private List<HourlyForecastModel> forecastCollection;
        Random random;

        public HourlyForecastCollection(List<HourlyForecastModel> forecastCollection)
        {
            this.forecastCollection = forecastCollection;
            random = new Random();
        }

        public int Count
        {
            get
            {
                return forecastCollection.Count;
            }
        }

        public HourlyForecastModel this[int i]
        {
            get { return forecastCollection[i]; }
        }
    }

    public class HourlyForeCastViewHolder : RecyclerView.ViewHolder
    {
        public TextView Hour { get; set; }
        public ImageView Image { get; set; }
        public TextView Degrees { get; set; }

        public HourlyForeCastViewHolder(View itemView) : base(itemView)
        {
            Hour = itemView.FindViewById<TextView>(Resource.Id.hourly_forecast_time);
            Image = itemView.FindViewById<ImageView>(Resource.Id.hourly_forecast_image);
            Degrees = itemView.FindViewById<TextView>(Resource.Id.hourly_forecast_degrees);
        }
    }

    public class HourlyAdapter : RecyclerView.Adapter
    {
        public HourlyForecastCollection forecastCollection;

        public HourlyAdapter(HourlyForecastCollection forecastCollection)
        {
            this.forecastCollection = forecastCollection;
        }
        public override int ItemCount
        {
            get
            {
                return forecastCollection.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            HourlyForeCastViewHolder viewHolder = holder as HourlyForeCastViewHolder;
            viewHolder.Hour.Text = forecastCollection[position].Hour.ToString();
            viewHolder.Image.SetImageResource(forecastCollection[position].ImageResource);
            viewHolder.Degrees.Text = forecastCollection[position].Degrees.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_view_hourly_forecast, parent, false);
            HourlyForeCastViewHolder viewHolder = new HourlyForeCastViewHolder(itemView);

            return viewHolder;
        }
    }
}