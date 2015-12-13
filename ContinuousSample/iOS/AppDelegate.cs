using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ContinuousSample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			#if DEBUG
			new Continuous.Server.HttpServer(this).Run();
			#endif

			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

