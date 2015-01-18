using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;


namespace Xamarin_Styles.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new Xamarin_Styles.App());
        }
    }
}
