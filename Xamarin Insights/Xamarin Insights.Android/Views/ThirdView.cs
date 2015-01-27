using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Xamarin_Insights.Android.Views
{
    [Activity(Label = "View for ThirdViewModel")]
    public class ThirdView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ThirdView);
        }
    }
}