using HolaXamarinFormsXAML.ViewModels.Base;
using System.Windows.Input;

namespace HolaXamarinFormsXAML.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private int _clicCounter;

        private DelegateCommand _helloCommand;

        public MainViewModel()
        {
            _clicCounter = 0;
        }

        public string Message
        {
            get { return string.Format("Botón pulsado {0} veces", _clicCounter); }
        }

        public ICommand HelloCommand
        {
            get { return _helloCommand = _helloCommand ?? new DelegateCommand(HelloCommandDelegate); }
        }

        private void HelloCommandDelegate()
        {
            _clicCounter++;
            RaisePropertyChanged("Message");
        }
    }
}
