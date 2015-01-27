using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin_Insights.Iphone.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
            {
               EdgesForExtendedLayout = UIRectEdge.None;
            }
			   
            var button = new UIButton(new CGRect(10, 10, 300, 40));
            button.SetTitle("Go to Second", UIControlState.Normal);
            Add(button);
  
            var set = this.CreateBindingSet<FirstView, ViewModels.FirstViewModel>();
            set.Bind(button).To(vm => vm.GotoSecondViewCommand);

            set.Apply();
        }
    }
}