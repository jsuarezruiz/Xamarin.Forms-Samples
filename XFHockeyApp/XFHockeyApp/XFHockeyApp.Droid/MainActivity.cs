using Android.App;
using Android.Content.PM;
using Android.OS;
using HockeyApp;
using XFHockeyApp.Services.Logger;

namespace XFHockeyApp.Droid
{
    [Activity (Label = "XFHockeyApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            CrashManager.Register(this, LoggerConfig.HockeyAppDroid);

            global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new XFHockeyApp.App ());
		}
	}
}

