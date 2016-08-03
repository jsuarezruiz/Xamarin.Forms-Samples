namespace XamarinForms_CustomRenders.ViewModels
{
    using System.Windows.Input;
    using Base;
    using Views;
    using Xamarin.Forms;

    public class MainViewModel : ViewModelBase
    {
        // Services
        private readonly INavigation _navigationService;

        // Commands
        private ICommand _navigateToExtendControlCommand;
        private ICommand _navigateToExtendControlRendererCommand;
        private ICommand _navigateToExtendPageCommand;

        public MainViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand NavigateToExtendControlCommand
        {
            get
            {
                return
                    _navigateToExtendControlCommand =
                        _navigateToExtendControlCommand ?? new DelegateCommand(NavigateToExtendControlCommandExecute);
            }
        }

        public ICommand NavigateToExtendControlRendererCommand
        {
            get
            {
                return
                    _navigateToExtendControlRendererCommand =
                        _navigateToExtendControlRendererCommand ?? new DelegateCommand(NavigateToExtendControlRendererCommandExecute);
            }
        }

        public ICommand NavigateToExtendPageCommand
        {
            get
            {
                return
                    _navigateToExtendPageCommand =
                        _navigateToExtendPageCommand ?? new DelegateCommand(NavigateToExtendPageCommandExecute);
            }
        }

        private async void NavigateToExtendControlCommandExecute()
        {
            await _navigationService.PushModalAsync(new ExtendControlView());
        }

        private async void NavigateToExtendControlRendererCommandExecute()
        {
            await _navigationService.PushModalAsync(new CustomControlRendererView());
        }

        private async void NavigateToExtendPageCommandExecute()
        {
            await _navigationService.PushModalAsync(new SwipeGesturedContentView());
        }
    }
}