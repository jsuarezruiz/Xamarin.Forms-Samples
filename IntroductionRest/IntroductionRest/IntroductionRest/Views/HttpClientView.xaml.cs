using IntroductionRest.ViewModels;
using Xamarin.Forms;

namespace IntroductionRest.Views
{
    public partial class HttpClientView : ContentPage
    {
        private object Parameter { get; set; }

        public HttpClientView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.HttpClientViewModel;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as HttpClientViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as HttpClientViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
