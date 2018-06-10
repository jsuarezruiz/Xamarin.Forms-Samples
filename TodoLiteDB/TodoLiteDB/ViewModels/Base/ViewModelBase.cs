using Xamarin.Forms;

namespace TodoLiteDB.ViewModels.Base
{
    public abstract class ViewModelBase : BindableObject
    {
        public virtual void OnAppearing(object navigationContext)
        {
        }

        public virtual void OnDisappearing()
        {
        }
    }
}