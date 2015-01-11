using System;
using Xamarin.Forms;

namespace Xamarin_Behaviors.Behaviors
{
    public class RandomColorButtonBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button bindable)
        {
            bindable.Clicked += ButtonClicked;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            bindable.Clicked -= ButtonClicked;
            base.OnDetachingFrom(bindable);
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
                button.BackgroundColor = GetRandomColor();
        }

        private Color GetRandomColor()
        {
            var color = new Color();
            var randomGen = new Random();
            int index = randomGen.Next(1, 5);
            switch (index)
            {
                case 1:
                    {
                        color = Color.Red;
                    }
                    break;
                case 2:
                    {
                        color = Color.Blue;
                    }
                    break;
                case 3:
                    {
                        color = Color.Green;
                    }
                    break;
                case 4:
                    {
                        color = Color.Yellow;
                    }
                    break;
            }

            return color;
        }
    }
}
