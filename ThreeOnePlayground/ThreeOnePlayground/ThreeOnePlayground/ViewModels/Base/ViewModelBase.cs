using System.Threading.Tasks;
using ThreeOnePlayground.Services.Navigation;
using Xamarin.Forms;

namespace ThreeOnePlayground.ViewModels.Base
{
    public class ViewModelBase : BindableObject
    {
        private bool _isBusy;

        protected readonly INavigationService NavigationService;

        public ViewModelBase()
        {
            NavigationService = Locator.Instance.Resolve<INavigationService>();
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}