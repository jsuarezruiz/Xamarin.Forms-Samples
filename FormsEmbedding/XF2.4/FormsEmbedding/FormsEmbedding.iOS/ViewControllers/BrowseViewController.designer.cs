// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FormsEmbedding.iOS
{
    [Register ("ItemsViewController")]
    partial class BrowseViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AddItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Settings { get; set; }

        [Action ("Settings_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Settings_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AddItem != null) {
                AddItem.Dispose ();
                AddItem = null;
            }

            if (Settings != null) {
                Settings.Dispose ();
                Settings = null;
            }
        }
    }
}