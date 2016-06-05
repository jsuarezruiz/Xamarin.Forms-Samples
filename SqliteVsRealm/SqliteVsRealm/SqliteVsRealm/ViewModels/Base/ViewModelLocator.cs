using Microsoft.Practices.Unity;
using SqliteVsRealm.Services.Realm;

namespace SqliteVsRealm.ViewModels.Base
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
            _container.RegisterType<IRealmService, RealmService>();
            _container.RegisterType<ISqliteService, SqliteService>();
        }

        public MainViewModel MainViewModel
        {
            get { return _container.Resolve<MainViewModel>(); }
        }
    }
}