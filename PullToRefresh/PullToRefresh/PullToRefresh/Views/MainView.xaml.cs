using PullToRefresh.ViewModels;
using Xamarin.Forms;

namespace PullToRefresh.Views
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
