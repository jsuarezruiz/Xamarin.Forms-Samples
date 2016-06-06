using Microsoft.Practices.Unity;
using XFHockeyApp.Services.Logger;

namespace XFHockeyApp.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<MainViewModel>();

            // Services     
            _container.RegisterType<ILoggerService, LoggerService>();
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
    }
}