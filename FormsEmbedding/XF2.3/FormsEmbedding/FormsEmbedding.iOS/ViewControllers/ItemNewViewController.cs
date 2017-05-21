using System;
using FormsEmbedding.Helpers;
using FormsEmbedding.Model;
using FormsEmbedding.ViewModel;
using UIKit;

namespace FormsEmbedding.iOS
{
	public partial class ItemNewViewController : UIViewController
    {
        public Item Item { get; set; }
        public ItemsViewModel ViewModel { get; set; }

		public ItemNewViewController(IntPtr handle) : base(handle)
		{

        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            btnSaveItem.TouchUpInside += async (sender, e) =>
			{
				var _item = new Item();
				_item.Text = txtTitle.Text;
				_item.Description = txtDesc.Text;

                await ViewModel.AddItem(_item);
                NavigationController.PopViewController(true);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

