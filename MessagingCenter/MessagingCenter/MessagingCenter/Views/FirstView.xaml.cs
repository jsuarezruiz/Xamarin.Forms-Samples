
using Xamarin.Forms;

namespace MessagingCenter.Views
{
    public partial class FirstView : ContentPage
    {
        private object Parameter { get; set; }

        public FirstView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.FirstViewModel;
        }
    }
}
