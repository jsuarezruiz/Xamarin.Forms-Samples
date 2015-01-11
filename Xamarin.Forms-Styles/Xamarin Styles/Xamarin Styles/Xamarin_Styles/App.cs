using Xamarin.Forms;
using Xamarin_Styles.Views;

namespace Xamarin_Styles
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
