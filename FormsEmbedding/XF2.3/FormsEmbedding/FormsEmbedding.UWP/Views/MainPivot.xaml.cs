using FormsEmbedding.Forms.Views;
using FormsEmbedding.Model;
using FormsEmbedding.UWP.Pages;
using FormsEmbedding.ViewModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FormsEmbedding.UWP.Views
{
    public sealed partial class MainPivot : Page
    {
        public ItemsViewModel BrowseViewModel { get; private set; }
        public AboutViewModel AboutViewModel { get; private set; }

        Task loadItems;

        public MainPivot()
        {
            NavigationCacheMode = NavigationCacheMode.Required;

            InitializeComponent();

            BrowseViewModel = new ItemsViewModel();
            AboutViewModel = new AboutViewModel();

            loadItems = BrowseViewModel.ExecuteLoadItemsCommand();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (BrowseViewModel.Items.Count == 0)
                loadItems.Wait();
        }

        public void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormsWindowsPage), typeof(SettingsView));
        }

        public void AddItem_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddItems), BrowseViewModel);
        }

        private void GvItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as Item;
            this.Frame.Navigate(typeof(BrowseItemDetail), item);
        }

        private void PivotItemChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    Toolbar.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Toolbar.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}