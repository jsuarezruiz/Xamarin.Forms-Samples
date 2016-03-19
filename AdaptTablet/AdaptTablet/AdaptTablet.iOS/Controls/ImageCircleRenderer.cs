using AdaptTablet.Controls.CircleImageAbstraction;
using AdaptTablet.iOS.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircleImage), typeof(ImageCircleRenderer))]
namespace AdaptTablet.iOS.Controls
{
    public class ImageCircleRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            double min = Math.Min(Element.Width, Element.Height);

            Control.Layer.CornerRadius = (float)(min / 2.0);
            Control.Layer.MasksToBounds = false;
            Control.ClipsToBounds = true;
        }
    }
}
