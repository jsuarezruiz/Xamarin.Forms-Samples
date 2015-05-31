namespace FormulaOneApp.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using ErgastAPI.Services.Driver;
    using ErgastAPI.Model.Driver;
    using Base;

    public class DriverDetailViewModel : ViewModelBase
    {
        // Variables
        private Driver _driver;
        private int _champs;
        private int _poles;
        private int _wins;
        private int _races;

        // Services
        private IDriverService _driverService;

        public DriverDetailViewModel(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public Driver Driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                RaisePropertyChanged();
            }
        }

        public int Champs
        {
            get { return _champs; }
            set
            {
                _champs = value;
                RaisePropertyChanged();
            }
        }

        public int Poles
        {
            get { return _poles; }
            set
            {
                _poles = value;
                RaisePropertyChanged();
            }
        }

        public int Wins
        {
            get { return _wins; }
            set
            {
                _wins = value;
                RaisePropertyChanged();
            }
        }

        public int Races
        {
            get { return _races; }
            set
            {
                _races = value;
                RaisePropertyChanged();
            }
        }

        public override async void OnAppearing(object navigationContext)
        {
            var driver = navigationContext as Driver;

            if (driver != null)
            {
                Driver = driver;
                await LoadDriverInfoAsync(driver.DriverId);
            }

            base.OnAppearing(navigationContext);
        }

        private async Task LoadDriverInfoAsync(string driver)
        {
            var driverResult = await _driverService.GetDriverResultsAsync(driver);

            foreach (var race in driverResult.Races)
            {
                Races = Races + 1;
                foreach (var result in race.Results)
                {
                    if (result.Position.Equals("1", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Wins = Wins + 1;
                    }
                }
            }
        }
    }
}
