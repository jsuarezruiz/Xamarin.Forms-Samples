using TodoLiteDB.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoLiteDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
            if (BindingContext is TodoListViewModel viewModel)
                viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            if (BindingContext is TodoListViewModel viewModel)
                viewModel.OnDisappearing();
        }
    }
}
