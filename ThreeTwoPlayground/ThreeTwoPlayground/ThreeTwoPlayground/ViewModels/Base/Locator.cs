using Autofac;
using System;
using ThreeTwoPlayground.Services.Navigation;

namespace ThreeTwoPlayground.ViewModels.Base
{
    public class Locator
    {
        private IContainer _container;
        private ContainerBuilder _containerBuilder;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        public Locator()
        {
            _containerBuilder = new ContainerBuilder();

            _containerBuilder.RegisterType<NavigationService>().As<INavigationService>();

            _containerBuilder.RegisterType<ButtonPaddingsViewModel>();
            _containerBuilder.RegisterType<CommandableSpansViewModel>();
            _containerBuilder.RegisterType<EditorPlaceholderViewModel>();
            _containerBuilder.RegisterType<MainViewModel>();
            _containerBuilder.RegisterType<OnPlatformMarkupExtensionsViewModel>();
            _containerBuilder.RegisterType<OthersViewModel>();
            _containerBuilder.RegisterType<PageTitleViewModel>();
            _containerBuilder.RegisterType<RoundedCornersBoxViewModel>();
            _containerBuilder.RegisterType<SwipeGestureViewModel>();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = _containerBuilder.Build();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _containerBuilder.RegisterType<TImplementation>().As<TInterface>();
        }

        public void Register<T>() where T : class
        {
            _containerBuilder.RegisterType<T>();
        }

        public void Build()
        {
            _container = _containerBuilder.Build();
        }
    }
}