using System;
using System.Collections.Generic;
using System.Windows.Input;
using XamarinInsights.Services.Navigation;
using XamarinInsights.ViewModels.Base;

namespace XamarinInsights.ViewModels
{
    public class FirstViewModel : ViewModelBase
    {
        // Commands
        private ICommand _navigateCommand;

        //Services
        private INavigationService _navigationService;

        public FirstViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand NavigateCommand
        {
            get { return _navigateCommand = _navigateCommand ?? new DelegateCommand(NavigateCommandExecute); }
        }

        public void NavigateCommandExecute()
        {
            Xamarin.Insights.Track("navigateto secondview", new Dictionary<string, string> {
                {"time", DateTime.Now.ToString()}
            });

            _navigationService.NavigateTo<SecondViewModel>();
        }
    }
}
