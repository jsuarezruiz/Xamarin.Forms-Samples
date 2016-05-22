using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoSqlite.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
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
