using AdaptTablet.ErgastAPI.Services.Driver;
using AdaptTablet.Services.Menu;
using AdaptTablet.Services.Navigation;
using Microsoft.Practices.Unity;

namespace AdaptTablet.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<ExtendedSplashViewModel>();
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<MainMenuViewModel>();
            _container.RegisterType<DriverListViewModel>();
            _container.RegisterType<DriverDetailViewModel>();

            // Services     
            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<IMenuService, MenuService>();
            _container.RegisterType<IDriverService, DriverService>();
        }

        public ExtendedSplashViewModel ExtendedSplashViewModel
        {
            get { return _container.Resolve<ExtendedSplashViewModel>(); }
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

        public MainMenuViewModel MainMenuViewModel
        {
            get { return _container.Resolve<MainMenuViewModel>(); }
        }

        public DriverListViewModel DriverListViewModel
        {
            get { return _container.Resolve<DriverListViewModel>(); }
        }

        public DriverDetailViewModel DriverDetailViewModel
        {
            get { return _container.Resolve<DriverDetailViewModel>(); }
        }
    }
}