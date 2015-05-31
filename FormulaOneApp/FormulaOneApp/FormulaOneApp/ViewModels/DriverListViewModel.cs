namespace FormulaOneApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ErgastAPI.Model.Driver;
    using Services.Navigation;
    using ErgastAPI.Services.Driver;
    using Base;

    public class DriverListViewModel : ViewModelBase
    {
        // Services
        private INavigationService _navigationService;
        private IDriverService _driverService;

        // Variables
        private ObservableCollection<Driver> _drivers;
        private Driver _driver;

        public DriverListViewModel(IDriverService driverService, INavigationService navigationService)
        {
            _driverService = driverService;
            _navigationService = navigationService;
        }

        public ObservableCollection<Driver> Drivers
        {
            get { return _drivers; }
            set
            {
                _drivers = value;
                RaisePropertyChanged();
            }
        }

        public Driver Driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                _navigationService.NavigateTo<DriverDetailViewModel>(_driver);
            }
        }

        public override async void OnAppearing(object navigationContext)
        {
            await LoadDriversAsync();

            base.OnAppearing(navigationContext);
        }

        private async Task LoadDriversAsync()
        {
            var result = await _driverService.GetDriverCollectionAsync();

            Drivers = new ObservableCollection<Driver>();
            foreach (var driver in result.Drivers)
            {
                Drivers.Add(driver);
            }
        }
    }
}