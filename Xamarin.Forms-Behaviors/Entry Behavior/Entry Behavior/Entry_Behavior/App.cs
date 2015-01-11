using Entry_Behavior.Views;
using Xamarin.Forms;

namespace Entry_Behavior
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
