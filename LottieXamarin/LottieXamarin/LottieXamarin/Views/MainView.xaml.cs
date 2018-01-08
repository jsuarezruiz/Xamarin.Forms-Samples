using LottieXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LottieXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();

            BindingContext = new MainViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainViewModel>(this, AppSettings.PlayMessage, (sender) =>
            {
                LottieView.Play();
            });

            MessagingCenter.Subscribe<MainViewModel>(this, AppSettings.PauseMessage, (sender) =>
            {
                LottieView.Pause();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<MainViewModel>(this, AppSettings.PlayMessage);
            MessagingCenter.Unsubscribe<MainViewModel>(this, AppSettings.PauseMessage);
        }
    }
}