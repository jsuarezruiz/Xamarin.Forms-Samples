using System.Windows.Input;
using ThreeTwoPlayground.ViewModels.Base;
using Xamarin.Forms;

namespace ThreeTwoPlayground.ViewModels
{
    public class CommandableSpansViewModel : ViewModelBase
    {
        private int _counter;
        private string _span1;
        private string _span2;
        private string _span3;
        private string _counterMessage;

        public CommandableSpansViewModel()
        {
            Span1 = "This is a single ";
            Span2 = "clickable";
            Span3 = " label";
            CounterMessage = string.Empty;
        }

        public string Span1
        {
            get { return _span1; }
            set
            {
                _span1 = value;
                OnPropertyChanged();
            }
        }

        public string Span2
        {
            get { return _span2; }
            set
            {
                _span2 = value;
                OnPropertyChanged();
            }
        }

        public string Span3
        {
            get { return _span3; }
            set
            {
                _span3 = value;
                OnPropertyChanged();
            }
        }

        public string CounterMessage
        {
            get { return _counterMessage; }
            set
            {
                _counterMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand TapCommand => new Command(TapCounter);

        private void TapCounter()
        {
            _counter++;
            CounterMessage = string.Format("Label clicked {0} times", _counter);
        }
    }
}