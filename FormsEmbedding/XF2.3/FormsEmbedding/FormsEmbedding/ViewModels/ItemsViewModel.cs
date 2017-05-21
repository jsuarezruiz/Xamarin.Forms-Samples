using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FormsEmbedding.Helpers;
using FormsEmbedding.Model;

namespace FormsEmbedding.ViewModel
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<Item>();
            var task = ExecuteLoadItemsCommand();
            task.Wait();
        }

        public async Task AddItem(Item item)
        {
            var _item = item as Item;
            Items.Add(_item);
            await DataStore.AddItemAsync(_item);
        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        ItemDetailViewModel detailsViewModel;
    }
}