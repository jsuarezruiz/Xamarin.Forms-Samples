using AgeCalc.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AgeCalc.Views
{
    public partial class MainView : ContentPage
    {
        private const uint AnimationDurantion = 250;

        private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

        public MainView()
        {
            InitializeComponent();

            BindingContext = App.Locator.MainViewModel;
        }

        protected override void OnAppearing()
        {
            (BindingContext as MainViewModel).OnAppearing(null);

            tapGestureRecognizer.Tapped += OnBannerTapped;
            ImageGrid.GestureRecognizers.Add(tapGestureRecognizer);
        }

        protected override void OnDisappearing()
        {
            (BindingContext as MainViewModel).OnDisappearing();

            tapGestureRecognizer.Tapped -= OnBannerTapped;
            ImageGrid.GestureRecognizers.Remove(tapGestureRecognizer);
        }

        private async void OnBannerTapped(Object sender, EventArgs e)
        {
            var visualElement = (VisualElement)sender;

            await Task.WhenAll(
                visualElement.ScaleTo(0, AnimationDurantion, Easing.CubicInOut)
            );

            (BindingContext as MainViewModel).Reset();

            await Task.WhenAll(
             visualElement.ScaleTo(1, AnimationDurantion, Easing.CubicIn)
         );
        }
    }
}