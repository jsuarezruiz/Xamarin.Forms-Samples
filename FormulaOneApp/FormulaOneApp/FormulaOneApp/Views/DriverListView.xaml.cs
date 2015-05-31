namespace FormulaOneApp.Views
{
    using ViewModels;
    using Xamarin.Forms;

    public partial class DriverListView : ContentPage
    {
        private object Parameter { get; set; }

        public DriverListView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;
            BindingContext = App.Locator.DriverListViewModel;
        }

        protected override void OnAppearing()
        {
            var mainViewModel = BindingContext as DriverListViewModel;
            if (mainViewModel != null) mainViewModel.OnAppearing(null);
        }

        protected override void OnDisappearing()
        {
            var mainViewModel = BindingContext as DriverListViewModel;
            if (mainViewModel != null) mainViewModel.OnDisappearing();
        }
    }
}
