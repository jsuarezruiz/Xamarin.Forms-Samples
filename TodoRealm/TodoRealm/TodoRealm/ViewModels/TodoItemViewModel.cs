using System.Windows.Input;
using TodoRealm.Models;
using TodoRealm.Services.Navigation;
using TodoRealm.Services.Realm;
using TodoRealm.ViewModels.Base;

namespace TodoRealm.ViewModels
{
    public class TodoItemViewModel : ViewModelBase
    {
        private int _id;
        private string _name;
        private string _notes;
        private bool _done;
        private TodoItem _item;

        private ICommand _saveCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private INavigationService _navigationService;
        private IRealmService _realmService;

        public TodoItemViewModel(
            INavigationService navigationService,
            IRealmService realmService)
        {
            _navigationService = navigationService;
            _realmService = realmService;
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged();
            }
        }

        public bool Done
        {
            get { return _done; }
            set
            {
                _done = value;
                RaisePropertyChanged();
            }
        }

        public TodoItem Item
        {
            get { return _item; }
            set { _item = value; }
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
                Id = todoItem.Id;
                Name = todoItem.Name;
                Notes = todoItem.Notes;
                Done = todoItem.Done;

                Item = todoItem;
            }

            base.OnAppearing(navigationContext);
        }


        private void SaveCommandExecute()
        {
            var item = new TodoItem
            {
                Id = Id,
                Name = Name,
                Notes = Notes,
                Done = Done
            };

            _realmService.Insert(item);
            _navigationService.NavigateBack();
        }

        private void DeleteCommandExecute()
        {
            _realmService.Remove(Item);
            _navigationService.NavigateBack();
        }

        private void CancelCommandExecute()
        {
            _navigationService.NavigateBack();
        }
    }
}