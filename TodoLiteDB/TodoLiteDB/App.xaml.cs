using TodoLiteDB.ViewModels.Base;
using TodoLiteDB.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TodoLiteDB
{
    public partial class App : Application
    {
        private static Locator _locator;

        public static Locator Locator
        {
            get { return _locator = _locator ?? new Locator(); }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TodoListView(null));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
