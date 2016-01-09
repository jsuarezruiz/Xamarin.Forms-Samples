
using Xamarin.Forms;

namespace MessagingCenter.Views
{
    public partial class SecondView : ContentPage
    {
        private object Parameter { get; set; }

        public SecondView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.SecondViewModel;
        }
    }
}
