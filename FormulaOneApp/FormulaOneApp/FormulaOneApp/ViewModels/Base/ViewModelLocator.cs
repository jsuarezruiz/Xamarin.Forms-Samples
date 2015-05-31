using FormulaOneApp.ErgastAPI.Services.Driver;
using FormulaOneApp.ErgastAPI.Services.Standings;

namespace FormulaOneApp.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using ViewModels;
    using Services.Navigation;
    using Services.Dialog;
    using Services.Internet;
    using Services.Storage;
    using ErgastAPI.Services.Race;


    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

			// ViewModels
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<DriverListViewModel>();
            _container.RegisterType<DriverDetailViewModel>(); 
            _container.RegisterType<StandingsViewModel>();

            // Servicios
            _container.RegisterType<INavigationService, NavigationService>();

            _container.RegisterType<IInternetService>();
            _container.RegisterType<IDialogService>();
            _container.RegisterType<IStorageService>();

            _container.RegisterType<IDriverService, DriverService>();
            _container.RegisterType<IStandingService, StandingService>();
            _container.RegisterType<IRaceService, RaceService>();
		}

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

        public DriverListViewModel DriverListViewModel
        {
            get { return _container.Resolve<DriverListViewModel>(); }
        }
        public DriverDetailViewModel DriverDetailViewModel
        {
            get { return _container.Resolve<DriverDetailViewModel>(); }
        }

        public StandingsViewModel StandingsViewModel
        {
            get { return _container.Resolve<StandingsViewModel>(); }
        }
	}
}
