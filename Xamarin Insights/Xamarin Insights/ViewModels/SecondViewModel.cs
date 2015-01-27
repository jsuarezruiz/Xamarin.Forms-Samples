using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Xamarin_Insights.ViewModels
{
    public class SecondViewModel
          : MvxViewModel
    {
        private MvxCommand _gotoThirdViewCommand;

        public ICommand GotoThirdViewCommand
        {
            get
            {
                _gotoThirdViewCommand = _gotoThirdViewCommand ?? new MvxCommand(DoGotoThirdViewCommand);
                return _gotoThirdViewCommand;
            }
        }

        private void DoGotoThirdViewCommand()
        {
            ShowViewModel<ThirdViewModel>(new { parameter = "Test" });
        }
    }
}
