namespace AdaptTablet.ViewModels
{
    using System;
    using OxyPlot;
    using OxyPlot.Series;
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
        private PlotModel _plotModel;

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

        public PlotModel PlotModel
        {
            get { return _plotModel; }
            set
            {
                _plotModel = value;
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
            var currentYear = DateTime.Today.Year;

            int second = 0;
            int third = 0;
            int four = 0;
            int five = 0;

            for (int i = currentYear; i > 2000; i--)
            {
                var driverResult = await _driverService.GetDriverResultsAsync(driver, i.ToString());
                foreach (var race in driverResult.Races)
                {
                    Races = Races + 1;
                    foreach (var result in race.Results)
                    {
                        if (result.Position.Equals("1", StringComparison.CurrentCultureIgnoreCase))
                        {
                            Wins = Wins + 1;
                        }
                        if (result.Position.Equals("2", StringComparison.CurrentCultureIgnoreCase))
                        {
                            second = second + 1;
                        }
                        if (result.Position.Equals("3", StringComparison.CurrentCultureIgnoreCase))
                        {
                            third = third + 1;
                        }
                        if (result.Position.Equals("4", StringComparison.CurrentCultureIgnoreCase))
                        {
                            four = four + 1;
                        }
                        if (result.Position.Equals("5", StringComparison.CurrentCultureIgnoreCase))
                        {
                            five = five + 1;
                        }
                    }
                }
            }

            PlotModel = new PlotModel
            {
                Title = "Positions"
            };

            var pieSlice = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            pieSlice.Slices.Add(new PieSlice("1º", Wins) { IsExploded = true });
            pieSlice.Slices.Add(new PieSlice("2º", second) { IsExploded = true });
            pieSlice.Slices.Add(new PieSlice("3º", third) { IsExploded = true });
            pieSlice.Slices.Add(new PieSlice("4º", four) { IsExploded = true });
            pieSlice.Slices.Add(new PieSlice("5º", five) { IsExploded = true });

            PlotModel.Series.Add(pieSlice);

            RaisePropertyChanged("PlotModel");
        }
    }
}
