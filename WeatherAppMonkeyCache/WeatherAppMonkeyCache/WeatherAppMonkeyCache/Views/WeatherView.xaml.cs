using MonkeyCache.FileStore;
using WeatherAppMonkeyCache.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherAppMonkeyCache.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherView : ContentPage
    {
        public WeatherView()
        {
            InitializeComponent();

            Barrel.ApplicationId = "com.refractored.weatherappmonkeycache";

            BindingContext = new WeatherViewModel();
        }

        protected override async void OnAppearing()
        {
            if (BindingContext is WeatherViewModel)
            {
                await ((WeatherViewModel)BindingContext).GetWeatherAsync();
            }

            base.OnAppearing();
        }
    }
}