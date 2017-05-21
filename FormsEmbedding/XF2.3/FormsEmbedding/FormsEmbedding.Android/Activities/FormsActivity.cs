using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using FormsEmbedding.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsEmbedding.Droid.Activities
{
    [Activity(Label = "@string/app_name", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class FormsActivity : FormsAppCompatActivity
    {
        public static bool IsFormsInitialized;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var view = Intent.Extras.GetString("View");
            var viewPath = typeof(XamarinFormsApp).Namespace + ".Views." + view;
            var viewType = typeof(XamarinFormsApp).Assembly.GetType(viewPath);

            if (!IsFormsInitialized)
            {
                global::Xamarin.Forms.Forms.Init(this, bundle);
                IsFormsInitialized = true;
            }

            LoadApplication(new XamarinFormsApp(viewType));
        }
    }
}