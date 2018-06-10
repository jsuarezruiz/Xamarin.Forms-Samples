using System.Windows.Input;
using TodoLiteDB.Models;
using TodoLiteDB.Services.LiteDB;
using TodoLiteDB.Services.Navigation;
using TodoLiteDB.ViewModels.Base;
using Xamarin.Forms;

namespace TodoLiteDB.ViewModels
{
    public class TodoItemViewModel : ViewModelBase
    {
        private TodoItem _item;

        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private INavigationService _navigationService;
        private ILiteDBService _liteDBService;

        public TodoItemViewModel(
            INavigationService navigationService,
            ILiteDBService LiteDBService)
        {
            _navigationService = navigationService;
            _liteDBService = LiteDBService;
        }

        public TodoItem Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new Command(SaveCommandExecute); }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand = _deleteCommand ?? new Command(DeleteCommandExecute); }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand = _cancelCommand ?? new Command(CancelCommandExecute); }
        }

        public override void OnAppearing(object navigationContext)
        {
            if (navigationContext is TodoItem todoItem)
            {
                Item = todoItem;
            }

            base.OnAppearing(navigationContext);
        }


        private void SaveCommandExecute()
        {
            _liteDBService.CreateItem(Item);
            _navigationService.NavigateBack();
        }

        private void DeleteCommandExecute()
        {
            _liteDBService.DeleteItem(Item);
            _navigationService.NavigateBack();
        }

        private void CancelCommandExecute()
        {
            _navigationService.NavigateBack();
        }
    }
}