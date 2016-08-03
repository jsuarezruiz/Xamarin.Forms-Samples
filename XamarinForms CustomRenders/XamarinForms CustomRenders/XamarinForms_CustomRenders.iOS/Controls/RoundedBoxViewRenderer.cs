using System.ComponentModel;
using XamarinForms_CustomRenders.CustomControls;
using XamarinForms_CustomRenders.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof (RoundedBoxView), typeof (RoundedBoxViewRenderer))]

namespace XamarinForms_CustomRenders.iOS.Controls
{
    public class RoundedBoxViewRenderer : ViewRenderer<RoundedBoxView, UIView>
    {
        private UIView _childView;

        protected override void OnElementChanged(ElementChangedEventArgs<RoundedBoxView> e)
        {
            base.OnElementChanged(e);

            RoundedBoxView rbv = e.NewElement;
            if (rbv != null)
            {
                var shadowView = new UIView();

                _childView = new UIView
                {
                    BackgroundColor = rbv.Color.ToUIColor(),
                    Layer =
                    {
                        CornerRadius = (float) rbv.CornerRadius,
                        BorderColor = rbv.Stroke.ToCGColor(),
                        BorderWidth = (float) rbv.StrokeThickness,
                        MasksToBounds = true
                    },
                    AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
                };

                shadowView.Add(_childView);

                SetNativeControl(shadowView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName)
                _childView.Layer.CornerRadius = (float) Element.CornerRadius;
            else if (e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName)
                _childView.Layer.BorderColor = Element.Stroke.ToCGColor();
            else if (e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
                _childView.Layer.BorderWidth = (float) Element.StrokeThickness;
            else if (e.PropertyName == BoxView.ColorProperty.PropertyName)
                _childView.BackgroundColor = Element.Color.ToUIColor();
        }
    }
}