using Android.Text.Util;
using XamarinForms_CustomRenders.CustomControls;
using XamarinForms_CustomRenders.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HyperLinkControl), typeof(HyperLinkControlRenderer))]
namespace XamarinForms_CustomRenders.Droid.Controls
{
    public class HyperLinkControlRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var nativeEditText = Control;

                Linkify.AddLinks(nativeEditText, MatchOptions.All);
            }
        }
    }
}