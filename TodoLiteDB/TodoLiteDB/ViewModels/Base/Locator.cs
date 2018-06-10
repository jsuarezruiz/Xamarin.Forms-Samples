using Autofac;
using TodoLiteDB.Services.LiteDB;
using TodoLiteDB.Services.Navigation;

namespace TodoLiteDB.ViewModels.Base
{
    public class Locator
    {
        private static IContainer _container;

        public Locator()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            builder.RegisterType<TodoListViewModel>();
            builder.RegisterType<TodoItemViewModel>();

            // Services     
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<LiteDBService>().As<ILiteDBService>();

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