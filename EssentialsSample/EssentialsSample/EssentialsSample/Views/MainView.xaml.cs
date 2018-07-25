using EssentialsSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EssentialsSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();

            BindingContext = new MainViewModel();
		}
	}
}