using System.Windows.Input;
using XFHockeyApp.Services.Logger;
using XFHockeyApp.ViewModels.Base;

namespace XFHockeyApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ILoggerService _loggerService;

        private ICommand _customEventCommand;

        public MainViewModel(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public ICommand CustomEventCommand
        {
            get { return _customEventCommand = _customEventCommand ?? new DelegateCommand(CustomEventCommandExecute); }
        }

        private void CustomEventCommandExecute()
        {
            _loggerService.TrackEvent("CustomEventCommand");
        }
    }
}
