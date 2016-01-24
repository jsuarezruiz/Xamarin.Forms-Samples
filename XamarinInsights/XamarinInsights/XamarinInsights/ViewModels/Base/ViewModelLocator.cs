using Microsoft.Practices.Unity;
using XamarinInsights.Services.Navigation;

namespace XamarinInsights.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<FirstViewModel>();
            _container.RegisterType<SecondViewModel>();

            // Services
            _container.RegisterType<INavigationService, NavigationService>();
        }

        public FirstViewModel FirstViewModel
        {
            get { return _container.Resolve<FirstViewModel>(); }
        }

        public SecondViewModel SecondViewModel
        {
            get { return _container.Resolve<SecondViewModel>(); }
        }
    }
}