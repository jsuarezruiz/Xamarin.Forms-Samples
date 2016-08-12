using IntroductionRest.Services.Navigation;
using IntroductionRest.ViewModels.Base;
using System.Windows.Input;

namespace IntroductionRest.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _httpClientCommand;
        private ICommand _httpWebRequestCommand;
        private ICommand _restSharpCommand;

        private INavigationService _navigationService;
        
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand HttpClientCommand
        {
            get { return _httpClientCommand = _httpClientCommand ?? new DelegateCommand(HttpClientCommandExecute); }
        }

        public ICommand HttpWebRequestCommand
        {
            get { return _httpWebRequestCommand = _httpWebRequestCommand ?? new DelegateCommand(HttpWebRequestCommandExecute); }
        }

        public ICommand RestSharpCommand
        {
            get { return _restSharpCommand = _restSharpCommand ?? new DelegateCommand(RestSharpCommandExecute); }
        }

        private void HttpClientCommandExecute()
        {
            _navigationService.NavigateTo<HttpClientViewModel>();
        }

        private void HttpWebRequestCommandExecute()
        {
            _navigationService.NavigateTo<HttpWebRequestViewModel>();
        }

        private void RestSharpCommandExecute()
        {
            _navigationService.NavigateTo<RestSharpViewModel>();
        }
    }
}