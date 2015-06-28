namespace DependencyServiceSample.ViewModels
{
    using System.Windows.Input;
    using Services.Call;
    using Xamarin.Forms;
    using Base;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private string _phone;

        // Services
        private ICallService _callService;

        // Commands
        private DelegateCommand _callCommand;

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
            }

        }
        public ICommand CallCommand
        {
            get { return _callCommand = _callCommand ?? new DelegateCommand(CallCommandExecute); }
        }

        private void CallCommandExecute()
        {
            if (string.IsNullOrEmpty(Phone))
                return;

            _callService = DependencyService.Get<ICallService>();

            _callService.MakeCall(Phone);
        }
    }
}
