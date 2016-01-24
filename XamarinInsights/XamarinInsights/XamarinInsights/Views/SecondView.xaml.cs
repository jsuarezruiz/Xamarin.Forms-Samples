using Xamarin.Forms;

namespace XamarinInsights.Views
{
    public partial class SecondView : ContentPage
    {
        private object Parameter { get; set; }

        public SecondView(object parameter)
        {
            InitializeComponent();

            BindingContext = App.Locator.SecondViewModel;
        }
    }
}
