using Xamarin.Forms;

namespace Xamarin.Forms_Effects.Effects
{
    public class ShadowEffect : RoutingEffect
    {
        public float Radius { get; set; }

        public Color Color { get; set; }

        public float DistanceX { get; set; }

        public float DistanceY { get; set; }

        public ShadowEffect() : base ("Xamarin.LabelShadowEffect")
		{
        }
    }
}
