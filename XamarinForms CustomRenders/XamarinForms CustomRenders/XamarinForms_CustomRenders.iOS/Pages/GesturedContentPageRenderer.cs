using XamarinForms_CustomRenders.CustomPages;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace XamarinForms_CustomRenders.iOS.Pages
{
    public class GesturedContentPageRenderer : PageRenderer
	{
        GesturedContentPage _page;

		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

			_page = (GesturedContentPage)e.NewElement;

			// Subscribe to the events here
			if (_page.CaptureSwipeRightToLeft) {
				NativeView.AddGestureRecognizer (new UISwipeGestureRecognizer (g => _page.OnSwipeRightToLeft()) { Direction = UISwipeGestureRecognizerDirection.Left });
			}

			if (_page.CaptureSwipeLeftToRight) {
				NativeView.AddGestureRecognizer (new UISwipeGestureRecognizer (g => _page.OnSwipeLeftToRight()) { Direction = UISwipeGestureRecognizerDirection.Right });
			}

			if (_page.CaptureSwipeBottomToTop) {
				NativeView.AddGestureRecognizer (new UISwipeGestureRecognizer (g => _page.OnSwipeBottomToTop()) { Direction = UISwipeGestureRecognizerDirection.Up });
			}

			if (_page.CaptureSwipeTopToBottom) {
				NativeView.AddGestureRecognizer (new UISwipeGestureRecognizer (g => _page.OnSwipeTopToBottom()) { Direction = UISwipeGestureRecognizerDirection.Down });
			}

			if (_page.CaptureTap) {
				NativeView.AddGestureRecognizer (new UITapGestureRecognizer (g => _page.OnTap()) { NumberOfTapsRequired = 1 });
			}

			if (_page.CaptureLongTap)
			{
				NativeView.AddGestureRecognizer (new UILongPressGestureRecognizer (g => _page.OnLongTap()));
			}
		}
	}
}