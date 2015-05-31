namespace FormulaOneApp.Views
{
    using ViewModels;
    using Xamarin.Forms;

    public partial class DriverDetailView : ContentPage
    {
        private object Parameter { get; set; }

        public DriverDetailView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;
            BindingContext = App.Locator.DriverDetailViewModel;
        }

        protected override void OnAppearing()
        {
            var mainViewModel = BindingContext as DriverDetailViewModel;
            if (mainViewModel != null) mainViewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            var mainViewModel = BindingContext as DriverDetailViewModel;
            if (mainViewModel != null) mainViewModel.OnDisappearing();
        }
    }
}
