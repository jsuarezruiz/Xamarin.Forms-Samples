using SqliteVsRealm.ViewModels.Base;
using SqliteVsRealm.Views;
using System.Diagnostics;
using Xamarin.Forms;

namespace SqliteVsRealm
{
    public class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get { return _locator = _locator ?? new ViewModelLocator(); }
        }

        public App()
        {
            MainPage = new NavigationPage(new MainView(null));
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}