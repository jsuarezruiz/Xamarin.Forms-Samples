using Android.App;
using Android.OS;

using Xamarin.Forms.Platform.Android;

namespace HolaXamarinFormsXAML.Droid
{
    [Activity(Label = "HolaXamarinFormsXAML", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(App.RootPage);
        }
    }
}

