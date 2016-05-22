using SQLite.Net.Async;
using System.Diagnostics;
using TodoSqlite.ViewModels.Base;
using TodoSqlite.Views;
using Xamarin.Forms;

namespace TodoSqlite
{
    public class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get { return _locator = _locator ?? new ViewModelLocator(); }
        }

        public App()
        {
            MainPage = new NavigationPage(new TodoListView(null));
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}
