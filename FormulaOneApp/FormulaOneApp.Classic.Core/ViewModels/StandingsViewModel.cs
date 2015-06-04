namespace FormulaOneApp.Classic.Core.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Cirrious.MvvmCross.ViewModels;
    using ErgastAPI.Model.Standing;
    using ErgastAPI.Services.Standings;

    public class StandingsViewModel : MvxViewModel
    {
        // Services
        private IStandingService _standingService;

        // Variables
        private ObservableCollection<DriverStanding> _standing;

        public StandingsViewModel(IStandingService standingService)
        {
            _standingService = standingService;

            LoadStandingsAsync();
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