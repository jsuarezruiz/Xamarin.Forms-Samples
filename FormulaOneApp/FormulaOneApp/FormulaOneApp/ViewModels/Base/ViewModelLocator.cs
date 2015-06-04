namespace FormulaOneApp.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using ViewModels;
    using Services.Navigation;
    using Services.Internet;
    using ErgastAPI.Services.Driver;
    using ErgastAPI.Services.Circuits;
    using ErgastAPI.Services.Standings;
    using Xamarin.Forms;
    using ErgastAPI.Services.Race;

    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<CircuitListViewModel>();
            _container.RegisterType<CircuitDetailViewModel>();
            _container.RegisterType<DriverListViewModel>();
            _container.RegisterType<DriverDetailViewModel>();
            _container.RegisterType<StandingsViewModel>();

            // Servicios
            _container.RegisterType<INavigationService, NavigationService>();

            IInternetService internetService = DependencyService.Get<IInternetService>();
            _container.RegisterInstance(internetService);

            _container.RegisterType<IDriverService, DriverService>();
            _container.RegisterType<IStandingService, StandingService>();
            _container.RegisterType<IRaceService, RaceService>();
            _container.RegisterType<ICircuitService, CircuitService>();
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

        public CircuitListViewModel CircuitListViewModel
        {
            get { return _container.Resolve<CircuitListViewModel>(); }
        }

        public CircuitDetailViewModel CircuitDetailViewModel
        {
            get { return _container.Resolve<CircuitDetailViewModel>(); }
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
