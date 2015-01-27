using System;
using System.Diagnostics;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Xamarin_Insights.ViewModels
{
    public class ThirdViewModel
           : MvxViewModel
    {
        public void Init(string parameter)
        {
            Parameter = parameter;
        }

        private string _parameter;
        public string Parameter
        {
            get { return _parameter; }
            set { _parameter = value; RaisePropertyChanged(() => Parameter); }
        }

        private MvxCommand _doExceptionCommand;

        public ICommand ExceptionCommand
        {
            get
            {
                _doExceptionCommand = _doExceptionCommand ?? new MvxCommand(DoExceptionCommand);
                return _doExceptionCommand;
            }
        }

        private void DoExceptionCommand()
        {
            try
            {
                throw new Exception("New Exception!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
