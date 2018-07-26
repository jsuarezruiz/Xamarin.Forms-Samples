using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreeOnePlayground.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabsView : TabbedPage
	{
		public TabsView ()
		{
			InitializeComponent ();
		}
	}
}