using WeatherAppMonkeyCache.Views;
using Xamarin.Forms;

namespace WeatherAppMonkeyCache
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new CustomNavigationPage(new WeatherView());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
