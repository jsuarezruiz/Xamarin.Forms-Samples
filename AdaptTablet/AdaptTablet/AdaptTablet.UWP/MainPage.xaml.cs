namespace AdaptTablet.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new AdaptTablet.App());
        }
    }
}
