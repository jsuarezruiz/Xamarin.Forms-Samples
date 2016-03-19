using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;
using AdaptTablet;
using AdaptTablet.ViewModels;

namespace AdaptTablet.Views
{
    public partial class ExtendedSplashView : ContentPage
    {
        public ExtendedSplashView()
        {
            InitializeComponent();

            BindingContext = App.Locator.ExtendedSplashViewModel;

			NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = BindingContext as ExtendedSplashViewModel;
			if (viewModel != null) viewModel.OnAppearing(null);

			await Task.Delay (2000);

			await Navigation.PushAsync (new MainView ());

			var views = Navigation.NavigationStack.ToList();
			foreach(var view in views)
			{
				Navigation.RemovePage(view);
			}
        }
    }
}
