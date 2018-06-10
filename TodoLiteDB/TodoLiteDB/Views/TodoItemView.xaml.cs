using TodoLiteDB.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoLiteDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
            if (BindingContext is TodoItemViewModel viewModel)
                viewModel.OnAppearing(Parameter);
        }

        protected override void OnDisappearing()
        {
            if (BindingContext is TodoItemViewModel viewModel)
                viewModel.OnDisappearing();
        }
    }
}
