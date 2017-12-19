using Autofac;
using TodoRealm.Services.Navigation;
using TodoRealm.Services.Realm;

namespace TodoRealm.ViewModels.Base
{
    public class ViewModelLocator
    {
        private static IContainer _container;

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            builder.RegisterType<TodoListViewModel>();
            builder.RegisterType<TodoItemViewModel>();

            // Services     
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<RealmService>().As<IRealmService>();

            if (_container != null)
            {
                _container.Dispose();
            }

            _container = builder.Build();
        }

        public TodoListViewModel TodoListViewModel
        {
            get { return _container.Resolve<TodoListViewModel>(); }
        }

        public TodoItemViewModel TodoItemViewModel
        {
            get { return _container.Resolve<TodoItemViewModel>(); }
        }
    }
}