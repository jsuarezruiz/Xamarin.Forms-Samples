using System;
using System.Collections.Specialized;
using Foundation;
using FormsEmbedding.ViewModel;
using UIKit;
using Xamarin.Forms;
using FormsEmbedding.Forms.Views;
using FormsEmbedding.Forms;

namespace FormsEmbedding.iOS
{
	public partial class BrowseViewController : UITableViewController
	{
		UIRefreshControl refreshControl;

		public ItemsViewModel ViewModel { get; set; }

		public BrowseViewController(IntPtr handle) : base(handle)
		{
			ViewModel = new ItemsViewModel();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Setup UITableView.
			refreshControl = new UIRefreshControl();
			refreshControl.ValueChanged += RefreshControl_ValueChanged;
			TableView.Add(refreshControl);
			TableView.Source = new ItemsDataSource(ViewModel);

			Title = ViewModel.Title;

			ViewModel.PropertyChanged += IsBusy_PropertyChanged;
			ViewModel.Items.CollectionChanged += Items_CollectionChanged;

		}
		public override async void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (ViewModel.Items.Count == 0)
				await ViewModel.ExecuteLoadItemsCommand();
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "NavigateToItemDetailSegue")
			{
				var controller = segue.DestinationViewController as BrowseItemDetailViewController;
				var indexPath = TableView.IndexPathForCell(sender as UITableViewCell);
				var item = ViewModel.Items[indexPath.Row];

				controller.ViewModel = new ItemDetailViewModel(item);
			}
            else if (segue.Identifier == "NavigateToNewItem")
            {
                var controller = segue.DestinationViewController as ItemNewViewController;
                controller.ViewModel = ViewModel;
            }
		}

		async void RefreshControl_ValueChanged(object sender, EventArgs e)
		{
			if (!ViewModel.IsBusy && refreshControl.Refreshing)
				await ViewModel.ExecuteLoadItemsCommand();

		}

		void IsBusy_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var propertyName = e.PropertyName;
			switch (propertyName)
			{
				case nameof(ViewModel.IsBusy):
					{
						InvokeOnMainThread(() =>
						{
							if (ViewModel.IsBusy && !refreshControl.Refreshing)
								refreshControl.BeginRefreshing();
							else if (!ViewModel.IsBusy)
								refreshControl.EndRefreshing();
						});
					}
					break;
			}
		}

		void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			InvokeOnMainThread(() => TableView.ReloadData());
		}

		[Action("UnwindToBrowse:")]
		public void UnwindToBrowse(UIStoryboardSegue segue)
		{
			Console.WriteLine("UNwound");
		}

        async partial void Settings_TouchUpInside(UIButton sender)
        {
            var settingsViewControler = XamarinFormsApp.GetPage<SettingsView>().CreateViewController();
            await PresentViewControllerAsync(settingsViewControler, true);
        }
    }

	class ItemsDataSource : UITableViewSource
	{
		static readonly NSString CELL_IDENTIFIER = new NSString("ITEM_CELL");

		ItemsViewModel viewModel;

		public ItemsDataSource(ItemsViewModel viewModel)
		{
			this.viewModel = viewModel;
		}

		public override nint RowsInSection(UITableView tableview, nint section) => viewModel.Items.Count;
		public override nint NumberOfSections(UITableView tableView) => 1;

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CELL_IDENTIFIER, indexPath);

			var item = viewModel.Items[indexPath.Row];
			cell.TextLabel.Text = item.Text;
			cell.DetailTextLabel.Text = item.Description;
			cell.LayoutMargins = UIEdgeInsets.Zero;

			return cell;
		}
	}
}