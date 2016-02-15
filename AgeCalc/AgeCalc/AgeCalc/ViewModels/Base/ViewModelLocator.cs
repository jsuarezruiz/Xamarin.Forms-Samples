using AgeCalc.Services;
using Microsoft.Practices.Unity;

namespace AgeCalc.ViewModels.Base
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
            _container.RegisterType<IAgeCalcService, AgeCalcService>();
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
    }
}
