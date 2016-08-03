using XamarinForms_CustomRenders.ViewModels;
using Xamarin.Forms;

namespace XamarinForms_CustomRenders.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(this.Navigation);
        }
    }
}
