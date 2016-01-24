using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinInsights.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
		private bool _isBusy;

		public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public virtual void OnAppearing(object navigationContext)
        {
        }

        public virtual void OnDisappearing()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
	}
}
