namespace FormulaOneApp.Classic.Core.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Cirrious.MvvmCross.ViewModels;
    using ErgastAPI.Model.Circuit;
    using ErgastAPI.Services.Circuits;

    public class CircuitListViewModel : MvxViewModel
    {
        // Services
        private ICircuitService _circuitService;

        // Variables
        private ObservableCollection<Circuit> _circuits;
        private Circuit _circuit;

        public CircuitListViewModel(ICircuitService circuitService)
        {
            _circuitService = circuitService;

            LoadDriversAsync();
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
                ShowViewModel<CircuitDetailViewModel>(_circuit);
            }
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
