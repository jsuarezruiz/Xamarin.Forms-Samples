using Microsoft.Practices.Unity;
using IntroductionRest.Services.Navigation;
using IntroductionRest.Services.Rest;

namespace IntroductionRest.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<HttpClientViewModel>();
            _container.RegisterType<HttpWebRequestViewModel>();
            _container.RegisterType<RestSharpViewModel>();

            // Services     
            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<IRestService, RestService>();
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }

        public HttpClientViewModel HttpClientViewModel
        {
            get { return _container.Resolve<HttpClientViewModel>(); }
        }

        public HttpWebRequestViewModel HttpWebRequestViewModel
        {
            get { return _container.Resolve<HttpWebRequestViewModel>(); }
        }

        public RestSharpViewModel RestSharpViewModel
        {
            get { return _container.Resolve<RestSharpViewModel>(); }
        }
    }
}