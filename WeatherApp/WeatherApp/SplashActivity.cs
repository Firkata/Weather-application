
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace WeatherApp
{
    [Activity(Label = "WeatherApp", Icon ="@drawable/appicon", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            StartActivity(typeof(MainActivity));
        }
    }
}