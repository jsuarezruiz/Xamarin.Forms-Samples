namespace FormulaOneApp.Views
{
    using Controls.StyledTabbedPageAbstraction;
    using ViewModels;

    public partial class MainView : StyledTabbedPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = App.Locator.MainViewModel;
        }

        protected override void OnAppearing()
        {
            var mainViewModel = BindingContext as MainViewModel;
            if (mainViewModel != null) mainViewModel.OnAppearing(null);
        }

        protected override void OnDisappearing()
        {
            var mainViewModel = BindingContext as MainViewModel;
            if (mainViewModel != null) mainViewModel.OnDisappearing();
        }
    }
}
