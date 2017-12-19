using XamarinForms_Services.ViewModels;
using Xamarin.Forms;

namespace XamarinForms_Services.Views
{
    public partial class ServiceView : ContentPage
    {
        public ServiceView()
        {
            InitializeComponent();

            BindingContext = new ServicesViewModel();
        }
    }
}
