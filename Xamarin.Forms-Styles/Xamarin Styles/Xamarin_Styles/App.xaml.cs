using Xamarin.Forms;
using Xamarin_Styles.Views;

namespace Xamarin_Styles
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainView());
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
