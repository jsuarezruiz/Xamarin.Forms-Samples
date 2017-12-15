using Autofac;
using TodoSqlite.Services.Navigation;
using TodoSqlite.Services.Sqlite;

namespace TodoSqlite.ViewModels.Base
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
            builder.RegisterType<SqliteService>().As<ISqliteService>();

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