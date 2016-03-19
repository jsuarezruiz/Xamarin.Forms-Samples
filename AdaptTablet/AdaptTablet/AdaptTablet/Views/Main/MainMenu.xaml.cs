using AdaptTablet.ViewModels;
using Xamarin.Forms;

namespace AdaptTablet.Views
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();

            BindingContext = App.Locator.MainMenuViewModel;
        }

		protected override void OnAppearing()
		{
			base.OnAppearing ();

			var viewModel = BindingContext as MainMenuViewModel;
			if (viewModel != null)
				viewModel.OnAppearing (null);
		}
    }
}