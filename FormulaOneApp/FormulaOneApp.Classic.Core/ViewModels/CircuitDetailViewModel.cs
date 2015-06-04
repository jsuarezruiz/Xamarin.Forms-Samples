namespace FormulaOneApp.Classic.Core.ViewModels
{
    using Cirrious.MvvmCross.ViewModels;
    using ErgastAPI.Model.Circuit;

    public class CircuitDetailViewModel : MvxViewModel
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
    }
}
