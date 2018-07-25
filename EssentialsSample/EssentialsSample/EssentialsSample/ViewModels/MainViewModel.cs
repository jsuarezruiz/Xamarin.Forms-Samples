using System.Windows.Input;
using Xamarin.Forms;

namespace EssentialsSample.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private string _batteryState;

        public string BatteryState
        {
            get { return _batteryState; }
            set
            {
                _batteryState = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetBatteryStateCommand => new Command(GetBatteryState);

        private void GetBatteryState()
        {
            var state = Xamarin.Essentials.Battery.State;

            BatteryState = state.ToString();
        }
    }
}