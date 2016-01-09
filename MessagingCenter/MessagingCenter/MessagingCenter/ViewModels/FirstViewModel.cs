using MessagingCenter.Services.Navigation;
using MessagingCenter.ViewModels.Base;
using System.Windows.Input;

namespace MessagingCenter.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        // Variables
        private string _info;

        //Services
        private readonly INavigationService _navigationService;

        // Commands
        private ICommand _navigateCommand;

        public FirstViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Info = "Navigate to Second View and go back to change this message.";

            Xamarin.Forms.MessagingCenter.Subscribe<FirstViewModel>(this, "Change", (sender) =>
            {
                Info = "Changed from Messaging Center";
            });
        }

        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                RaisePropertyChanged();
            }
        }

        public ICommand NavigateCommand
        {
            get { return _navigateCommand = _navigateCommand ?? new DelegateCommand(NavigateCommandExecute); }
        }

        public void NavigateCommandExecute()
        {
            _navigationService.NavigateTo<SecondViewModel>();
        }
    }
}