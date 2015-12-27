using Xamarin.Forms.Platform.UWP;

namespace ListViewPerformance.UWP
{
    public sealed partial class MainPage : WindowsPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new ListViewPerformance.App());
        }
    }
}
