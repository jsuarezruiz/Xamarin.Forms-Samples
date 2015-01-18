using Xamarin.Forms;
using Xamarin_Triggers.Views;

namespace Xamarin_Triggers
{
    public class App
    {
        public static Page GetMainPage()
        {
            var view = new MainView();
            return new NavigationPage(view);
        }
    }
}
