using RelativeSourceSample.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace RelativeSourceSample.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<TodoItem> _items;

        public MainViewModel()
        {
            LoadItems();
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

        public ICommand DeleteTodoItemCommand => new Command<TodoItem>(DeleteTodoItem);

        private void LoadItems()
        {
            Items = new ObservableCollection<TodoItem>
            {
                new TodoItem
                {
                    Name = "Create RelativeSource Demo"
                },
                new TodoItem
                {
                    Name = "Buy Milk"
                },
                new TodoItem
                {
                    Name = "Go for a walk"
                }
            };
        }

        void DeleteTodoItem(TodoItem todoItem)
        {
            Items?.Remove(todoItem);
        }
    }
}