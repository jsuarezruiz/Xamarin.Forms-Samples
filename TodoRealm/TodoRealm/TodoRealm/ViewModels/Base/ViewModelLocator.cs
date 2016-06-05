using Microsoft.Practices.Unity;
using TodoRealm.Services.Navigation;
using TodoRealm.Services.Realm;

namespace TodoRealm.ViewModels.Base
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
            _container.RegisterType<IRealmService, RealmService>();
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