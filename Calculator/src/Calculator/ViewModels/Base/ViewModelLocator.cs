namespace Calculator.ViewModels.Base
{
    using Microsoft.Practices.Unity;
    using ViewModels;

    public class ViewModelLocator
    {
        private readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<CalculatorViewModel>();
        }

        public CalculatorViewModel CalculatorViewModel
        {
            get { return _container.Resolve<CalculatorViewModel>(); }
        }
    }
}
