using Persistence.ViewModels;
using Persistence.ViewModels.Base;
using Persistence.Views;
using Xamarin.Forms;

namespace Persistence
{
    public class App : Application
    {
        private MainView _mainView;
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
            _mainView = new MainView();
            MainPage = new NavigationPage(_mainView);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            if (((NavigationPage)MainPage).CurrentPage == _mainView)
            {
                var viewModel = _mainView.BindingContext as MainViewModel;

                if (viewModel != null)
                    Application.Current.Properties["FirstName"] = viewModel.FirstName;
            }
        }

        protected override void OnResume()
        {
            if (((NavigationPage)MainPage).CurrentPage == _mainView)
            {
                if (Application.Current.Properties.ContainsKey("FirstName"))
                {
                    var firstName = (string)Application.Current.Properties["FirstName"];
                    var viewModel = _mainView.BindingContext as MainViewModel;

                    if (viewModel != null)
                        viewModel.FirstName = firstName;
                }
            }
        }
    }
}
