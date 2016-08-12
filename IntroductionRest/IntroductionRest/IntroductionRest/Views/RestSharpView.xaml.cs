using IntroductionRest.ViewModels;
using Xamarin.Forms;

namespace IntroductionRest.Views
{
    public partial class RestSharpView : ContentPage
    {
        private object Parameter { get; set; }

        public RestSharpView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.RestSharpViewModel;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as RestSharpViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as RestSharpViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
