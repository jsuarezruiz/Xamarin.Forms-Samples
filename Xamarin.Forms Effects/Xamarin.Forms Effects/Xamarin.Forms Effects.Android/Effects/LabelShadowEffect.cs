using System;
using System.Linq;
using Xamarin.Forms_Effects.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms_Effects.Effects;
using Android.Widget;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace Xamarin.Forms_Effects.Droid.Effects
{
    public class LabelShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        { 
            try
            {
                var control = Control as   TextView;
                var effect = (ShadowEffect)Element.Effects.FirstOrDefault(e => e is ShadowEffect);
                if (effect != null)
                {
                    float radius = effect.Radius;
                    float distanceX = effect.DistanceX;
                    float distanceY = effect.DistanceY;
                     var color = effect.Color.ToAndroid();
                    control.SetShadowLayer(radius, distanceX, distanceY, color);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
