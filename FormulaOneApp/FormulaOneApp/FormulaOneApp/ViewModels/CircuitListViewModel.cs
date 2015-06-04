namespace FormulaOneApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using ErgastAPI.Model.Circuit;
    using ErgastAPI.Services.Circuits;
    using Services.Navigation;
    using Base;

    public class CircuitListViewModel : ViewModelBase
    {
        // Services
        private INavigationService _navigationService;
        private ICircuitService _circuitService;

        // Variables
        private ObservableCollection<Circuit> _circuits;
        private Circuit _circuit;

        public CircuitListViewModel(ICircuitService circuitService, INavigationService navigationService)
        {
            _circuitService = circuitService;
            _navigationService = navigationService;
        }

        public ObservableCollection<Circuit> Circuits
        {
            get { return _circuits; }
            set
            {
                _circuits = value;
                RaisePropertyChanged();
            }
        }

        public Circuit Circuit
        {
            get { return _circuit; }
            set
            {
                _circuit = value;
                _navigationService.NavigateTo<CircuitDetailViewModel>(_circuit);
            }
        }

        public override async void OnAppearing(object navigationContext)
        {
            await LoadDriversAsync();

            base.OnAppearing(navigationContext);
        }

        private async Task LoadDriversAsync()
        {
            var result = await _circuitService.GetSeasonCircuitsCollectionAsync();

            Circuits = new ObservableCollection<Circuit>();

            foreach (var circuit in result.Circuits)
            {
                Circuits.Add(circuit);
            }

        }
    }
}
