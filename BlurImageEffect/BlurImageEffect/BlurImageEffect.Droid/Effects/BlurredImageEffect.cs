using System;
using System.Linq;
using BlurImageEffect.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BlurImageEffect.Effects;
using Android.Widget;
using Android.Graphics;
using Android.Renderscripts;
using System.Net;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(BlurredImageEffect), "BlurredImageEffect")]
namespace BlurImageEffect.Droid.Effects
{
    public class BlurredImageEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var imageView = Control as ImageView;
                var effect = (BlurredEffect)Element.Effects.FirstOrDefault(e => e is BlurredEffect);
                if (effect != null)
                {
                    var d = imageView.Drawable;
                    if (d != null)
                    {
                        var bitmap = GetImageBitmapFromUrl(effect.Url);

                        if (bitmap != null)
                        {
                            imageView.SetImageBitmap(CreateBlurredImage(effect.Radius, bitmap));
                            imageView.Invalidate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }


        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
        
        private Bitmap CreateBlurredImage(int radius, Bitmap originalBitmap)
        {
            Bitmap blurredBitmap;
            blurredBitmap = Bitmap.CreateBitmap(originalBitmap);

            var rs = RenderScript.Create(Forms.Context);
            var input = Allocation.CreateFromBitmap(rs, originalBitmap, Allocation.MipmapControl.MipmapFull, AllocationUsage.Script);
            var output = Allocation.CreateTyped(rs, input.Type);

            var script = ScriptIntrinsicBlur.Create(rs, Android.Renderscripts.Element.U8_4(rs));
            script.SetInput(input);
            script.SetRadius(radius);
            script.ForEach(output);

            output.CopyTo(blurredBitmap);

            return blurredBitmap;
        }
    }
}