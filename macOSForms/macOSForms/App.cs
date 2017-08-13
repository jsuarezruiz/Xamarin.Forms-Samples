using Xamarin.Forms;
using macOSForms.Views;

namespace macOSForms
{
    public class App : Application 
    {
        public App()
        {
            MainPage = new TipCalcView();
        }
    }
}