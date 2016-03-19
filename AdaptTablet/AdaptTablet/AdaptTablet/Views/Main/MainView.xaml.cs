using AdaptTablet.Views.Drivers.Tablet;
using Xamarin.Forms;

namespace AdaptTablet.Views
{
    public partial class MainView : MasterDetailPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = App.Locator.MainViewModel;

            Master = new MainMenu();


            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
                Detail = new NavigationPage(new DriverListTabletView(null));
            else
                Detail = new NavigationPage(new DriverListView(null));
        }
    }
}
