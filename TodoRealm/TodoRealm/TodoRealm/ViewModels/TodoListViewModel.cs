using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoRealm.Models;
using TodoRealm.Services.Navigation;
using TodoRealm.Services.Realm;
using TodoRealm.ViewModels.Base;

namespace TodoRealm.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private ObservableCollection<TodoItem> _items;
        private TodoItem _selectedItem;

        private ICommand _addCommand;

        private INavigationService _navigationService;
        private IRealmService _realmService;

        public TodoListViewModel(
            INavigationService navigationService,
            IRealmService realmService)
        {
            _navigationService = navigationService;
            _realmService = realmService;
        }

        public ObservableCollection<TodoItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged();
            }
        }

        public TodoItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                _navigationService.NavigateTo<TodoItemViewModel>(_selectedItem);
            }
        }

        public ICommand AddCommand
        {
            get { return _addCommand = _addCommand ?? new DelegateCommand(AddCommandExecute); }
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            var result = _realmService.GetAll();

            Items = new ObservableCollection<TodoItem>();
            foreach(var item in result)
            {
                Items.Add(item);
            }
        }

        private void AddCommandExecute()
        {
            var todoItem = new TodoItem();
            _navigationService.NavigateTo<TodoItemViewModel>(todoItem);
        }
    }
}
