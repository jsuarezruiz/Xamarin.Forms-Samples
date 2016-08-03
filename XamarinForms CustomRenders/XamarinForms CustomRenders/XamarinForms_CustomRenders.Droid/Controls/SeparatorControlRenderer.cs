using XamarinForms_CustomRenders.CustomControls;
using System.ComponentModel;
using Xamarin.Forms.Platform.Android;

namespace XamarinForms_CustomRenders.Droid.Controls
{
    public class SeparatorRenderer : ViewRenderer<SeparatorControl, SeparatorDroidView>
    {
        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<SeparatorControl> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            if (Control == null)
            {
                SetNativeControl(new SeparatorDroidView(Context));
            }

            SetProperties();
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            SetProperties();
        }

        /// <summary>
        /// Sets the properties.
        /// </summary>
        private void SetProperties()
        {
            Control.Thickness = Element.Thickness;
            Control.StrokeColor = Element.Color.ToAndroid();
            Control.StrokeType = Element.StrokeType;
            Control.Orientation = Element.Orientation;

            Control.Invalidate();
        }
    }
}