using System.Diagnostics;
using Xamarin.Forms;
using DataTemplateSelectors.ViewModels.Base;
using DataTemplateSelectors.Views;

namespace DataTemplateSelectors
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator = _locator ?? new ViewModelLocator();
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
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
