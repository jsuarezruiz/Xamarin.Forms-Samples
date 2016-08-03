using XamarinForms_CustomRenders.CustomPages;
using Xamarin.Forms;

namespace XamarinForms_CustomRenders.Views
{
    class SwipeGesturedContentView : GesturedContentPage
	{
        public SwipeGesturedContentView()
		{
			Title = "Gestures Content View";

			CaptureSwipeBottomToTop = true;
			CaptureSwipeTopToBottom = true;
			CaptureSwipeLeftToRight = true;
			CaptureSwipeRightToLeft = true;
			CaptureTap = true;
			CaptureLongTap = true;

			var directionDisplay = new Label () {
				Text = "Tap or Swipe!",
				Font = Font.SystemFontOfSize (30),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			Content = directionDisplay;

			OnSwipeLeftToRight += () => directionDisplay.Text = "-->";
			OnSwipeRightToLeft += () => directionDisplay.Text = "<--";
			OnSwipeTopToBottom += () => directionDisplay.Text = "\\/";
			OnSwipeBottomToTop += () => directionDisplay.Text = "/\\";
			OnTap += () => directionDisplay.Text = "Tapped";
			OnLongTap += () => directionDisplay.Text = "Long Tap";
		}
	}
}

