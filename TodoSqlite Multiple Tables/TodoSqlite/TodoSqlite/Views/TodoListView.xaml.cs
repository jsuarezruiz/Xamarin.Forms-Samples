using TodoSqlite.ViewModels;
using Xamarin.Forms;

namespace TodoSqlite.Views
{
    public partial class TodoListView : ContentPage
    {
        private object Parameter { get; set; }

        public TodoListView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.TodoListViewModel;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as TodoListViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as TodoListViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
