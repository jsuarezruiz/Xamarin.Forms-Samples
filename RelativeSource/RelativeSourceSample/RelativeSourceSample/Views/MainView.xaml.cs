using RelativeSourceSample.ViewModels;
using Xamarin.Forms;

namespace RelativeSourceSample.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}