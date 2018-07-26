using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreeTwoPlayground.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeGestureView : ContentPage
    {
        public class SwipeContainer : ContentView
        {
            public EventHandler SwipeLeft;
            public EventHandler SwipeRight;

            public SwipeContainer()
            {
                GestureRecognizers.Add(GetSwipeLeft());
                GestureRecognizers.Add(GetSwipeRight());
            }

            SwipeGestureRecognizer GetSwipeLeft()
            {
                var swipe = new SwipeGestureRecognizer
                {
                    Direction = SwipeDirection.Left
                };
                swipe.Swiped += (sender, args) => SwipeLeft?.Invoke(this, new EventArgs());
                return swipe;
            }

            SwipeGestureRecognizer GetSwipeRight()
            {
                var swipe = new SwipeGestureRecognizer
                {
                    Direction = SwipeDirection.Right
                };
                swipe.Swiped += (sender, args) => SwipeRight?.Invoke(this, new EventArgs());
                return swipe;
            }
        }

        public SwipeGestureView()
        {
            var box = new Image
            {
                BackgroundColor = Color.Red,
                WidthRequest = 250,
                HeightRequest = 250,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            var label = new Label { Text = "Swipe inside the red box." };

            var swipeContainer = new SwipeContainer { Content = box };
            swipeContainer.SwipeLeft += (sender, args) => label.Text = "<";
            swipeContainer.SwipeRight += (sender, args) => label.Text = ">";

            Content = new StackLayout
            {
                Children = { label, swipeContainer },
                Padding = new Thickness(20)
            };
        }
    }
}