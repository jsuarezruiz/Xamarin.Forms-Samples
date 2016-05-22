using Microsoft.Practices.Unity;
using TodoSqlite.Services.Navigation;
using TodoSqlite.Services.Realm;

namespace TodoSqlite.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IUnityContainer _container;

        public ViewModelLocator()
        {
            _container = new UnityContainer();

            // ViewModels
            _container.RegisterType<TodoListViewModel>();
            _container.RegisterType<TodoItemViewModel>();

            // Services     
            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<ISqliteService, SqliteService>();
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