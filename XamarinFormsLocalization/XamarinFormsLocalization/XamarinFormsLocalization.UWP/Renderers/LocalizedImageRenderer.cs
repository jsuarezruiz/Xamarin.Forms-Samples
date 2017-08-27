using System.Globalization;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Image), typeof(XamarinFormsLocalization.UWP.Renderers.LocalizedImageRenderer))]
namespace XamarinFormsLocalization.UWP.Renderers
{
    public class LocalizedImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var fileImageSource = e.NewElement.Source as FileImageSource;

                if (fileImageSource != null)
                {
                    var fileName = fileImageSource.File;
                    string currentUICulture = CultureInfo.CurrentUICulture.ToString();
                    e.NewElement.Source = Path.Combine("Assets/" + currentUICulture + "/" + fileName);
                }
            }
        }
    }
}