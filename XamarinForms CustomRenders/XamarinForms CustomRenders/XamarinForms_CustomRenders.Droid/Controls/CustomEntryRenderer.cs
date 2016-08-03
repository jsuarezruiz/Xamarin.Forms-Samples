using XamarinForms_CustomRenders.CustomControls;
using XamarinForms_CustomRenders.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace XamarinForms_CustomRenders.Droid.Controls
{
    internal class CustomEntryRenderer : EntryRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Do whatever you want to the textField here!
                Control.SetBackgroundColor(global::Android.Graphics.Color.DarkGray);
            }
        }
    }
}