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
            LoadApplication(new FormulaOneApp.App());
        }
    }
}