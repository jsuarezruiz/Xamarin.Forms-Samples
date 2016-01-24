using Android.App;
using Android.Content.PM;
using Android.OS;
using XamarinInsights.Common;

namespace XamarinInsights.Droid
{
    [Activity(Label = "XamarinInsights", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Initialize Insights
            Xamarin.Insights.Initialize(Consts.INSIGHTS_API_KEY, this);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

