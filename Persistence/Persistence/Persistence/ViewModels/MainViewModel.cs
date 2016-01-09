using Persistence.ViewModels.Base;

namespace Persistence.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Variables
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged();
            }
        }
    }
}
