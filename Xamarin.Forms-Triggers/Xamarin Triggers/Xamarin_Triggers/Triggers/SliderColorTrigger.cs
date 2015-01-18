using Xamarin.Forms;

namespace Xamarin_Triggers.Triggers
{
    public class SliderColorTrigger : TriggerAction<Slider>
    {
        protected override void Invoke(Slider sender)
        {
            var value = sender.Value;

            if (value < 40)
                sender.BackgroundColor = Color.Red;
            else if (value > 60)
                sender.BackgroundColor = Color.Green;
            else
                sender.BackgroundColor = Color.Black;
        }
    }
}
