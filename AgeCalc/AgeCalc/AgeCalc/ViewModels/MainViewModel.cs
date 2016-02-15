using AgeCalc.Services;
using AgeCalc.ViewModels.Base;
using System;
using System.Windows.Input;

namespace AgeCalc.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private DateTime _actual;
        private DateTime _birthDate;
        private string _age;

        private ICommand _calcCommand;

        public MainViewModel()
        {
            Actual = DateTime.Now;
            BirthDate = DateTime.Now;
        }

        public DateTime Actual
        {
            get { return _actual; }
            set
            {
                _actual = value;
                RaisePropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                RaisePropertyChanged();
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CalcCommand
        {
            get { return _calcCommand = _calcCommand ?? new DelegateCommand(CalcCommandExecute); }
        }

        private void CalcCommandExecute()
        {
            Age = Calculate().ToString();
        }

        public int Calculate()
        {
            return AgeCalculator.Calc(Actual, BirthDate);
        }

        public void Reset()
        {
            BirthDate = DateTime.Now;
            Age = null;
        }
    }
}
