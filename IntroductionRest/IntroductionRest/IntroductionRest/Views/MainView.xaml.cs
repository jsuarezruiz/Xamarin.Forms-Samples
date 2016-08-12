using IntroductionRest.ViewModels;
using Xamarin.Forms;

namespace IntroductionRest.Views
{
    public partial class MainView : ContentPage
    {
        private object Parameter { get; set; }

        public MainView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.MainViewModel;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as MainViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as MainViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
