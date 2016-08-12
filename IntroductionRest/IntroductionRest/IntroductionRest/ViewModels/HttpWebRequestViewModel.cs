using IntroductionRest.Services.Rest;
using IntroductionRest.ViewModels.Base;
using System.Windows.Input;

namespace IntroductionRest.ViewModels
{
    public class HttpWebRequestViewModel : ViewModelBase
    {
        private string _content;

        private ICommand _requestCommand;

        private IRestService _restService;

        public HttpWebRequestViewModel(IRestService restService)
        {
            _restService = restService;
        }

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                RaisePropertyChanged();
            }
        }

        public ICommand RequestCommand
        {
            get { return _requestCommand = _requestCommand ?? new DelegateCommand(RequestCommandExecute); }
        }

        private async void RequestCommandExecute()
        {
            Content = await _restService.GetRestServiceData(RestService.RestServiceType.HttpWebRequest);
        }
    }
}
