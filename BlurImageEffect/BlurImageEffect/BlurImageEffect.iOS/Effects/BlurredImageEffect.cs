using BlurImageEffect.iOS.Effects;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(BlurredImageEffect), "BlurredImageEffect")]
namespace BlurImageEffect.iOS.Effects
{
    public class BlurredImageEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            throw new NotImplementedException();
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}
