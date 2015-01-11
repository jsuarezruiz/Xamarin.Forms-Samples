using HolaXamarinFormsXAML.Views;
using Xamarin.Forms;

namespace HolaXamarinFormsXAML
{
	public class App
	{
        private static Page _mainView;
        public static Page RootPage
        {
            get { return _mainView ?? (_mainView = new MainView()); }
        }
	}
}
