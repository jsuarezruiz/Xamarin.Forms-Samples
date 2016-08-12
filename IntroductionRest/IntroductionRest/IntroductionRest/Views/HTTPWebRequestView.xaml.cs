using IntroductionRest.ViewModels;
using Xamarin.Forms;

namespace IntroductionRest.Views
{
    public partial class HTTPWebRequestView : ContentPage
    {
        private object Parameter { get; set; }

        public HTTPWebRequestView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.HttpWebRequestViewModel;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as HttpWebRequestViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as HttpWebRequestViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
