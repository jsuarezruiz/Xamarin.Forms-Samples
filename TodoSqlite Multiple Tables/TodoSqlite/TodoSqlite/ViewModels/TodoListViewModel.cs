using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoSqlite.Models;
using TodoSqlite.Services.Navigation;
using TodoSqlite.Services.Sqlite;
using TodoSqlite.ViewModels.Base;

namespace TodoSqlite.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private ObservableCollection<TodoItem> _items;
        private TodoItem _selectedItem;

        private ICommand _addCommand;

        private INavigationService _navigationService;
        private ISqliteService _sqliteService;

        public TodoListViewModel(
            INavigationService navigationService,
            ISqliteService sqliteService)
        {
            _navigationService = navigationService;
            _sqliteService = sqliteService;
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

        public override async void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            var result = await _sqliteService.GetAll();

            Items = new ObservableCollection<TodoItem>();
            foreach(var item in result)
            {
                Items.Add(item);
            }
        }

        private void AddCommandExecute()
        {
            var todoItem = new TodoItem
            {
                Steps = new System.Collections.Generic.List<Step>()
            };

            _navigationService.NavigateTo<TodoItemViewModel>(todoItem);
        }
    }
}
