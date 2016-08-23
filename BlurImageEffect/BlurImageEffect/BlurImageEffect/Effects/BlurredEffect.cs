using Xamarin.Forms;

namespace BlurImageEffect.Effects
{
    public class BlurredEffect : RoutingEffect
    {
        public string Url { get; set; }
        public int Radius { get; set; }

        public BlurredEffect() : base("Xamarin.BlurredImageEffect")
        {

        } 
    }
}
