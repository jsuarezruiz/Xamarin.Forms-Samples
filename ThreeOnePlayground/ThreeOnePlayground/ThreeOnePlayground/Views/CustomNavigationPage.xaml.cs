using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreeOnePlayground.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage() : base()
        {
            InitializeComponent();
        }

        public CustomNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}