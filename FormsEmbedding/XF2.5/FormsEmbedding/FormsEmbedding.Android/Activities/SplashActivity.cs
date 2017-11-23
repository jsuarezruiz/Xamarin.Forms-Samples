using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace FormsEmbedding.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/SplashTheme", MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var mainActivityIntent = new Intent(this, typeof(MainActivity));
            mainActivityIntent.AddFlags(ActivityFlags.ClearTop);
            mainActivityIntent.AddFlags(ActivityFlags.SingleTop);

            StartActivity(mainActivityIntent);
            Finish();
        }
    }
}