using Xamarin.Forms;
using Xamarin.Forms_Windows.Views;

namespace Xamarin.Forms_Windows
{
    public class App : Application
    {
        public App()
        {
            MainPage = new MainView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
