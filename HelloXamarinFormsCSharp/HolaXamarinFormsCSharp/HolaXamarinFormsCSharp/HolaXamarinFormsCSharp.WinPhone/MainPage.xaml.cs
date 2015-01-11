using Microsoft.Phone.Controls;
using Xamarin.Forms;

namespace HolaXamarinFormsCSharp.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();

            Content = HolaXamarinFormsCSharp.App.RootPage.ConvertPageToUIElement(this); 
        }
    }
}
