using Android.App;
using Android.OS;
using HockeyApp;

namespace AndroidHockeyApp
{
    [Activity(Label = "AndroidHockeyApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public const string HOCKEYAPP_APPID = "HOCKEYAPP_APPID";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            CrashManager.Register(this, HOCKEYAPP_APPID);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.YourMainView);
        }
    }
}

