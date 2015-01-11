using HolaXamarinFormsCSharp.Views;
using Xamarin.Forms;

namespace HolaXamarinFormsCSharp
{
	public static class App
	{
        private static Page _mainView;
        public static Page RootPage
        {
            get { return _mainView ?? (_mainView = new MainView()); }
        }
	}
}
