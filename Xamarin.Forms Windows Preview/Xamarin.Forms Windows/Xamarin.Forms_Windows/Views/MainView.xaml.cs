using Xamarin.Forms;
using Xamarin.Forms_Windows.ViewModels;

namespace Xamarin.Forms_Windows.Views
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
