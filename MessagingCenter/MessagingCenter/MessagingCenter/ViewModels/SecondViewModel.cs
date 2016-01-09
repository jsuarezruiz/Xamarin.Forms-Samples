using MessagingCenter.ViewModels.Base;

namespace MessagingCenter.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        public SecondViewModel()
        {
            Xamarin.Forms.MessagingCenter.Send(App.Locator.FirstViewModel, "Change");
        }
    }
}
