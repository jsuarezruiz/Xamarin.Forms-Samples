using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace FormulaOneApp.Classic.Android.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }
    }
}