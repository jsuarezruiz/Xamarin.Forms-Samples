using System;
using System.ComponentModel;
using System.Windows.Controls;
using HyperlinkCustomRender.Controls;
using HyperlinkCustomRender.WinPhone.Controls;
using Microsoft.Phone.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(HyperLinkControl), typeof(HyperLinkControlRenderer))]
namespace HyperlinkCustomRender.WinPhone.Controls
{
    public class HyperLinkControlRenderer : ViewRenderer<HyperLinkControl, HyperlinkButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<HyperLinkControl> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            var element = new HyperlinkButton
            {
                TargetName = Element.Text,
                Content = Element.Text
            };

            element.Click += (sender, args) =>
            {
                if (Element.NavigateUri.Contains("@"))
                {
                    var emailComposeTask = new EmailComposeTask { Subject = string.Empty, To = "mailto:" + Element.NavigateUri };
                    emailComposeTask.Show();
                }
                else if (Element.NavigateUri.Contains("www.") || 
                    Element.NavigateUri.Contains("http:"))
                {
                    var uri = Element.NavigateUri.StartsWith("http:")
                                  ? new Uri(Element.NavigateUri)
                                  : new Uri(@"http://" + Element.NavigateUri);

                    var webBrowserTask = new WebBrowserTask { Uri = uri };
                    webBrowserTask.Show();
                }
            };

            SetNativeControl(element);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ((e.PropertyName == Label.TextProperty.PropertyName))
                Control.Content = Element.Text;
        }
    }
}
