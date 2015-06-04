using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace FormulaOneApp.Classic.Android.Views
{
    [Activity(Label = "View for StandingsViewModel")]
    public class StandingsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.StandingsView);
        }
    }
}