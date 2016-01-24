using Xamarin.Forms;

namespace DataTemplateSelectors.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = App.Locator.MainViewModel;
        }
    }
}
