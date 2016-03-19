namespace AdaptTablet.Views
{
    using ErgastAPI.Model.Driver;
    using System;
    using ViewModels;
    using Xamarin.Forms;

    public partial class DriverListView : ContentPage
    {
        private object Parameter { get; set; }

        public Action<Driver> ItemSelected { get; set; }

        public DriverListView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;
            BindingContext = App.Locator.DriverListViewModel;
        }

        protected override void OnAppearing()
		{
			var viewModel = BindingContext as DriverListViewModel;
			if (viewModel != null) {
				viewModel.OnAppearing (null);	
				viewModel.ItemSelected = ItemSelected;
			}
		}

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as DriverListViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
