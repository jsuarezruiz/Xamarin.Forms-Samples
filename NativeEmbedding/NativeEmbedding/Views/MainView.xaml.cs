using Xamarin.Forms;

#if __IOS__
using CoreGraphics;
using UIKit;
using Xamarin.Forms.Platform.iOS;
#endif

#if __ANDROID__
using Android.Widget;
using Android.Views;
using Xamarin.Forms.Platform.Android;
#endif

namespace NativeEmbedding
{
    public partial class MainView : ContentPage
	{
		public MainView()
		{
			InitializeComponent();

#if __IOS__
            var uiButton = new UIButton(UIButtonType.RoundedRect);
            uiButton.SetTitle("Native iOS Button", UIControlState.Normal);
            uiButton.Font = UIFont.FromName("Helvetica", 14f);

            panel.Children.Add(uiButton);
#endif

#if __ANDROID__
			var button = new Android.Widget.Button (Forms.Context) { Text = "Native Android Button" };

			panel.Children.Add (button);
#endif
        }
    }
}
