
using Android.App;
using Android.App.Usage;
using Android.Content;
using Android.Net;

namespace WeatherApp.Common
{
    public static class ConnectionHelper
    {
        public static bool CheckNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            
            return activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting;
        }
    }
}