namespace FormulaOneApp.ViewModels
{
    using ErgastAPI.Model.Circuit;
    using Base;

    public class CircuitDetailViewModel : ViewModelBase
    {
        private Circuit _circuit;

        public Circuit Circuit
        {
            get { return _circuit; }
            set
            {
                _circuit = value;
                RaisePropertyChanged();
            }
        }

        public override void OnAppearing(object navigationContext)
        {
            var circuit = navigationContext as Circuit;

            if (circuit != null)
            {
                Circuit = circuit;
            }

            base.OnAppearing(navigationContext);
        }
    }
}
