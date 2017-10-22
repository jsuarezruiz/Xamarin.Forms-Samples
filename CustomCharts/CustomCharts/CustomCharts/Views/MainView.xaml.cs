using CustomCharts.ViewModels;
using Xamarin.Forms;

namespace CustomCharts.Views
{
	public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();

            BindingContext = new MainViewModel();
		}
	}
}