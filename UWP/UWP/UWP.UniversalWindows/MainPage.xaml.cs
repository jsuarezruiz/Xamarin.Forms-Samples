using Xamarin.Forms.Platform.UWP;

namespace UWP.UniversalWindows
{
    public sealed partial class MainPage : WindowsPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new UWP.App());
        }
    }
}
