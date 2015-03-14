namespace PullToRefresh.ViewModels
{
    using System.Linq;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Base;
    using Extensions;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private ObservableCollection<string> _items; 
        private bool _isBusy;
        private int _count;

        // Commands
        private DelegateCommandAsync _loadCommand;

        public ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public MainViewModel()
        {
            _count = 1;
            Items = new ObservableCollection<string>();

            for (int i = 0; i < 10; i++)
            {
                Items.Insert(0, _count.ToString());
                _count++;
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoadCommand
        {
            get { return _loadCommand ?? (_loadCommand = new DelegateCommandAsync(LoadCommandExecute)); }
        }

        private async Task LoadCommandExecute()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await Task.Delay(3000);

            for (int i = 0; i < 10; i++)
            {
                Items.Insert(0, _count.ToString());
                _count++;
            }

            IsBusy = false;
        }
    }
}
