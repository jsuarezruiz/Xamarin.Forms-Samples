namespace FormulaOneApp.Classic.Core.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Cirrious.MvvmCross.ViewModels;
    using ErgastAPI.Model.Driver;
    using ErgastAPI.Services.Driver;

    public class DriverListViewModel : MvxViewModel
    {
        // Services
        private IDriverService _driverService;

        // Variables
        private ObservableCollection<Driver> _drivers;
        private Driver _driver;

        public DriverListViewModel(IDriverService driverService)
        {
            _driverService = driverService; 
            
            LoadDriversAsync();
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
                ShowViewModel<DriverDetailViewModel>(_driver);
            }
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