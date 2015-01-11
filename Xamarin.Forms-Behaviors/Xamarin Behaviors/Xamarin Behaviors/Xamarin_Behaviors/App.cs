using Xamarin.Forms;
using Xamarin_Behaviors.Views;

namespace Xamarin_Behaviors
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
