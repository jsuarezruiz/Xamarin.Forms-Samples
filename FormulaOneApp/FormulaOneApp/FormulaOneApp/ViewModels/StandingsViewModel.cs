namespace FormulaOneApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Linq;
    using ErgastAPI.Model.Standing;
    using ErgastAPI.Services.Standings;
    using Base;

    public class StandingsViewModel : ViewModelBase
    {
        // Services
        private IStandingService _standingService;

        // Variables
        private ObservableCollection<DriverStanding> _standing;

        public StandingsViewModel(IStandingService standingService)
        {
            _standingService = standingService;
        }

        public ObservableCollection<DriverStanding> Standing
        {
            get { return _standing; }
            set
            {
                _standing = value;
                RaisePropertyChanged();
            }
        }

        public override async void OnAppearing(object navigationContext)
        {
            await LoadStandingsAsync();

            base.OnAppearing(navigationContext);
        }

        private async Task LoadStandingsAsync()
        {
            var result = await _standingService.GetSeasonDriverStandingsCollectionAsync();

            Standing = new ObservableCollection<DriverStanding>();
            foreach (var standing in result.StandingsLists.First().DriverStandings)
            {
                Standing.Add(standing);
            }
        }
    }
}
