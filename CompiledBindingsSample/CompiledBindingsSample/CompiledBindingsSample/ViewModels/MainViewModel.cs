using Xamarin.Forms;

namespace CompiledBindingsSample.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private string _value1;
        private string _value2;
        private string _value3;
        private string _value4;
        private string _value5;

        public MainViewModel()
        {
            Value1 = "Value1";
            Value2 = "Value2";
            Value3 = "Value3";
            Value4 = "Value4";
            Value5 = "Value5";
        }

        public string Value1
        {
            get { return _value1; }
            set
            {
                _value1 = value;
                OnPropertyChanged();
            }
        }

        public string Value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                OnPropertyChanged();
            }
        }

        public string Value3
        {
            get { return _value3; }
            set
            {
                _value3 = value;
                OnPropertyChanged();
            }
        }

        public string Value4
        {
            get { return _value4; }
            set
            {
                _value4 = value;
                OnPropertyChanged();
            }
        }

        public string Value5
        {
            get { return _value5; }
            set
            {
                _value5 = value;
                OnPropertyChanged();
            }
        }
    }
}