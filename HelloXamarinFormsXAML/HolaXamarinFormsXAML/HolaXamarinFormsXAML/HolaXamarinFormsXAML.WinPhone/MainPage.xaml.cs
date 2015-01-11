using Microsoft.Phone.Controls;
using Xamarin.Forms;

namespace HolaXamarinFormsXAML.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = HolaXamarinFormsXAML.App.RootPage.ConvertPageToUIElement(this); 
        }
    }
}
