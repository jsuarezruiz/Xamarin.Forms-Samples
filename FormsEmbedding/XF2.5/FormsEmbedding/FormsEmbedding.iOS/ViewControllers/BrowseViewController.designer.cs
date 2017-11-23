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
        UIKit.UIButton btnAddItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSettings { get; set; }

        [Action ("BtnSettings_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSettings_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnAddItem != null) {
                btnAddItem.Dispose ();
                btnAddItem = null;
            }

            if (btnSettings != null) {
                btnSettings.Dispose ();
                btnSettings = null;
            }
        }
    }
}