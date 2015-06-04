namespace FormulaOneApp.Views
{
    using ErgastAPI.Model.Circuit;
    using Xamarin.Forms.Maps;
    using ViewModels;
    using Xamarin.Forms;

    public partial class CircuitDetailView : ContentPage
    {
        private object Parameter { get; set; }

        public CircuitDetailView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;
            BindingContext = App.Locator.CircuitDetailViewModel;
        }

        protected override void OnAppearing()
        {
            var mainViewModel = BindingContext as CircuitDetailViewModel;
            if (mainViewModel != null) mainViewModel.OnAppearing(Parameter);

            var circuit = Parameter as Circuit;
            if (circuit != null)
            {
                var location = circuit.Location;
                var position =
                    new Position(double.Parse(location.Lat, System.Globalization.CultureInfo.InvariantCulture),
                        double.Parse(location.@long, System.Globalization.CultureInfo.InvariantCulture));
                MapControl.MoveToRegion( MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));

                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = circuit.CircuitName,
                    Address = circuit.CircuitId
                };
                MapControl.Pins.Add(pin);
            }
        }

        protected override void OnDisappearing()
        {
            var mainViewModel = BindingContext as CircuitDetailViewModel;
            if (mainViewModel != null) mainViewModel.OnDisappearing();
        }
    }
}
