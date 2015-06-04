namespace FormulaOneApp.Views
{
    using ViewModels;
    using Xamarin.Forms;

    public partial class CircuitListView : ContentPage
    {
        private object Parameter { get; set; }

        public CircuitListView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;
            BindingContext = App.Locator.CircuitListViewModel;
        }

        protected override void OnAppearing()
        {
            var mainViewModel = BindingContext as CircuitListViewModel;
            if (mainViewModel != null) mainViewModel.OnAppearing(null);
        }

        protected override void OnDisappearing()
        {
            var mainViewModel = BindingContext as CircuitListViewModel;
            if (mainViewModel != null) mainViewModel.OnDisappearing();
        }
    }
}
