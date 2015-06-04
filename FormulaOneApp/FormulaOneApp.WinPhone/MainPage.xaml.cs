namespace FormulaOneApp.WinPhone
{
    using Microsoft.Phone.Controls;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.WinPhone;

    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Forms.Init();
            OxyPlot.Xamarin.Forms.Platform.WP8.Forms.Init(); 
            Xamarin.FormsMaps.Init();
            LoadApplication(new FormulaOneApp.App());
        }
    }
}