using Android.Graphics;
using XamarinForms_CustomRenders.CustomControls;
using XamarinForms_CustomRenders.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRendererAttribute(typeof(RoundedBoxView),
    typeof(RoundedBoxViewRenderer))]
namespace XamarinForms_CustomRenders.Droid.Controls
{
    public class RoundedBoxViewRenderer : BoxRenderer
    {
        public RoundedBoxViewRenderer()
        {
            this.SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            var rbv = (RoundedBoxView)this.Element;

            var rc = new Rect();
            GetDrawingRect(rc);

            Rect interior = rc;
            interior.Inset((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);

            Paint p = new Paint
            {
                Color = rbv.Color.ToAndroid(),
                AntiAlias = true,
            };

            canvas.DrawRoundRect(new RectF(interior), (float)rbv.CornerRadius, (float)rbv.CornerRadius, p);

            p.Color = rbv.Stroke.ToAndroid();
            p.StrokeWidth = (float)rbv.StrokeThickness;
            p.SetStyle(Paint.Style.Stroke);

            canvas.DrawRoundRect(new RectF(rc), (float)rbv.CornerRadius, (float)rbv.CornerRadius, p);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName ||
                e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName ||
                e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName ||
                e.PropertyName == BoxView.ColorProperty.PropertyName)
            {
                Invalidate();
            }
        }
    }
}