using System.Windows.Input;
using TodoSqlite.Models;
using TodoSqlite.Services.Navigation;
using TodoSqlite.Services.Sqlite;
using TodoSqlite.ViewModels.Base;

namespace TodoSqlite.ViewModels
{
    public class TodoItemViewModel : ViewModelBase
    {
        private TodoItem _item;

        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private INavigationService _navigationService;
        private ISqliteService _sqliteService;

        public TodoItemViewModel(
            INavigationService navigationService,
            ISqliteService sqliteService)
        {
            _navigationService = navigationService;
            _sqliteService = sqliteService;
        }

        public TodoItem Item
        {
            get { return _item; }
            set
            {
                _item = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveCommandExecute); }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand = _deleteCommand ?? new DelegateCommand(DeleteCommandExecute); }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand = _cancelCommand ?? new DelegateCommand(CancelCommandExecute); }
        }

        public override void OnAppearing(object navigationContext)
        {
            var todoItem = navigationContext as TodoItem;

            if (todoItem != null)
            {
                Item = todoItem;
            }

            base.OnAppearing(navigationContext);
        }


        private async void SaveCommandExecute()
        {
            await _sqliteService.Insert(Item);
            _navigationService.NavigateBack();
        }

        private async void DeleteCommandExecute()
        {
            await _sqliteService.Remove(Item);
            _navigationService.NavigateBack();
        }

        private void CancelCommandExecute()
        {
            _navigationService.NavigateBack();
        }
    }
}