using Xamarin.Forms;

namespace XamarinInsights.Views
{
    public partial class FirstView : ContentPage
    {
        public FirstView()
        {
            InitializeComponent();

            BindingContext = App.Locator.FirstViewModel;
        }
    }
}
