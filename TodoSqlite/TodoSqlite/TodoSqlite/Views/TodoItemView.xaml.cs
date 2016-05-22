using TodoSqlite.ViewModels;
using Xamarin.Forms;

namespace TodoSqlite.Views
{
    public partial class TodoItemView : ContentPage
    {
        private object Parameter { get; set; }

        public TodoItemView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.TodoItemViewModel;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as TodoItemViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as TodoItemViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
