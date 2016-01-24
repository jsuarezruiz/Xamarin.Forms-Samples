using System;
using System.Collections.Generic;
using System.Windows.Input;
using XamarinInsights.Services.Navigation;
using XamarinInsights.ViewModels.Base;

namespace XamarinInsights.ViewModels
{
    public class SecondViewModel : ViewModelBase
    {
        // Commands
        private ICommand _eventCommand;
        private ICommand _identityCommand;
        private ICommand _warningCommand;
        private ICommand _errorCommand;
        private ICommand _exceptionCommand;

        // Services
        private INavigationService _navigationService;

        public SecondViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand EventCommand
        {
            get { return _eventCommand = _eventCommand ?? new DelegateCommand(EventCommandExecute); }
        }

        public ICommand IdentityCommand
        {
            get { return _identityCommand = _identityCommand ?? new DelegateCommand(IdentityCommandExecute); }
        }

        public ICommand WarningCommand
        {
            get { return _warningCommand = _warningCommand ?? new DelegateCommand(WarningCommandExecute); }
        }

        public ICommand ErrorCommand
        {
            get { return _errorCommand = _errorCommand ?? new DelegateCommand(ErrorCommandExecute); }
        }

        public ICommand ExceptionCommand
        {
            get { return _exceptionCommand = _exceptionCommand ?? new DelegateCommand(ExceptionCommandExecute); }
        }

        private void EventCommandExecute()
        {
            Xamarin.Insights.Track("goback", new Dictionary<string, string> {
                {"time", DateTime.Now.ToString()}
            });

            _navigationService.NavigateBack();
        }

        private void IdentityCommandExecute()
        {
            Xamarin.Insights.Identify("1", new Dictionary<string, string> {
                {Xamarin.Insights.Traits.Email, "jsuarezruiz@email.com"},
                {Xamarin.Insights.Traits.Name, "Javier"},
                {"time", DateTime.Now.ToString()}
            });
        }

        private void WarningCommandExecute()
        {
            try
            {
                throw new NotSupportedException("Oh oh!. Something bad happened.");
            }
            catch (Exception exp)
            {
                Xamarin.Insights.Report(exp, new Dictionary<string, string> {
                    {"time", DateTime.Now.ToString()}
                }, Xamarin.Insights.Severity.Warning);
            }
        }

        private void ErrorCommandExecute()
        {
            try
            {
                throw new NotSupportedException("Oh oh!. Something bad happened.");
            }
            catch (Exception exp)
            {
                Xamarin.Insights.Report(exp, new Dictionary<string, string> {
                    {"time", DateTime.Now.ToString()}
                }, Xamarin.Insights.Severity.Error);
            }
        }

        private void ExceptionCommandExecute()
        {
            throw new Exception("Unhandled Exception.");
        }
    }
}
