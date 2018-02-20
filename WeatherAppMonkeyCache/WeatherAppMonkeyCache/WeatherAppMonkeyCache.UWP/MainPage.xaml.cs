namespace WeatherAppMonkeyCache.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new WeatherAppMonkeyCache.App());
        }
    }
}