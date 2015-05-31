namespace FormulaOneApp.Views
{
    using ViewModels;
    using Xamarin.Forms;

    public partial class StandingsView : ContentPage
    { 
        private bool _hasAppearedOnce;

        private object Parameter { get; set; }

        public StandingsView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;
            BindingContext = App.Locator.StandingsViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var mainViewModel = BindingContext as StandingsViewModel;
            if (mainViewModel != null) mainViewModel.OnAppearing(null);

            if (!_hasAppearedOnce)
            {
                _hasAppearedOnce = true;
                var padding = (NameGrid.Width - MessagesListView.Height)/2;

                MessagesListView.HeightRequest = MessagesLayoutFrame.Width;
                MessagesLayoutFrameInner.WidthRequest = MessagesLayoutFrame.Width;
                MessagesLayoutFrameInner.Padding = new Thickness(0);
                MessagesLayoutFrame.Padding = new Thickness(0);
                MessagesLayoutFrame.IsClippedToBounds = true;
                AbsoluteLayout.SetLayoutBounds(MessagesLayoutFrameInner,
                    new Rectangle(0, 0 - padding, AbsoluteLayout.AutoSize, MessagesListView.Height - padding));
                MessagesLayoutFrameInner.IsClippedToBounds = true;
            }
        }

        protected override void OnDisappearing()
        {
            var mainViewModel = BindingContext as StandingsViewModel;
            if (mainViewModel != null) mainViewModel.OnDisappearing();
        }
    }
}
