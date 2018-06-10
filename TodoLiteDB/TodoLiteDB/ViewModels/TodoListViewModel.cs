using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoLiteDB.Models;
using TodoLiteDB.Services.LiteDB;
using TodoLiteDB.Services.Navigation;
using TodoLiteDB.ViewModels.Base;
using Xamarin.Forms;

namespace TodoLiteDB.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private ObservableCollection<TodoItem> _items;
        private TodoItem _selectedItem;

        private ICommand _addCommand;

        private INavigationService _navigationService;
        private ILiteDBService _liteDBService;

        public TodoListViewModel(
            INavigationService navigationService,
            ILiteDBService liteDBService)
        {
            _navigationService = navigationService;
            _liteDBService = liteDBService;
        }

        public ObservableCollection<TodoItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
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
            get { return _addCommand = _addCommand ?? new Command(AddCommandExecute); }
        }

        public override void OnAppearing(object navigationContext)
        {
            base.OnAppearing(navigationContext);

            var result = _liteDBService.ReadAllItems();

            Items = new ObservableCollection<TodoItem>();

            foreach (var item in result)
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