using Xamarin.Forms;

namespace XamarinForms_CustomRenders.CustomControls
{
    public class SeparatorControl : View
    {
        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create("Orientation", typeof(SeparatorOrientation), typeof(SeparatorControl), SeparatorOrientation.Horizontal, BindingMode.OneWay, null, null, null, null);

        public SeparatorOrientation Orientation
        {
            get
            {
                return (SeparatorOrientation)base.GetValue(SeparatorControl.OrientationProperty);
            }

            private set
            {
                base.SetValue(SeparatorControl.OrientationProperty, value);
            }
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create("Color", typeof(Color), typeof(SeparatorControl), Color.Default, BindingMode.OneWay, null, null, null, null);

        public Color Color
        {
            get
            {
                return (Color)base.GetValue(SeparatorControl.ColorProperty);
            }
            set
            {
                base.SetValue(SeparatorControl.ColorProperty, value);
            }
        }

        public static readonly BindableProperty ThicknessProperty =
            BindableProperty.Create("Thickness", typeof(double), typeof(SeparatorControl), (double)1, BindingMode.OneWay, null, null, null, null);

        public double Thickness
        {
            get
            {
                return (double)base.GetValue(SeparatorControl.ThicknessProperty);
            }
            set
            {
                base.SetValue(SeparatorControl.ThicknessProperty, value);
            }
        }

        public static readonly BindableProperty StrokeTypeProperty =
            BindableProperty.Create("StrokeType", typeof(StrokeType), typeof(SeparatorControl), StrokeType.Solid, BindingMode.OneWay, null, null, null, null);

        public StrokeType StrokeType
        {
            get
            {
                return (StrokeType)base.GetValue(SeparatorControl.StrokeTypeProperty);
            }
            set
            {
                base.SetValue(SeparatorControl.StrokeTypeProperty, value);
            }
        }

        public SeparatorControl()
        {
            UpdateRequestedSize();
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == ThicknessProperty.PropertyName ||
               propertyName == ColorProperty.PropertyName ||
               propertyName == StrokeTypeProperty.PropertyName ||
               propertyName == OrientationProperty.PropertyName)
            {
                UpdateRequestedSize();
            }
        }

        private void UpdateRequestedSize()
        {
            var minSize = Thickness;
            var optimalSize = Thickness;
            if (Orientation == SeparatorOrientation.Horizontal)
            {
                MinimumHeightRequest = minSize;
                HeightRequest = optimalSize;
                HorizontalOptions = LayoutOptions.FillAndExpand;
            }
            else
            {
                MinimumWidthRequest = minSize;
                WidthRequest = optimalSize;
                VerticalOptions = LayoutOptions.FillAndExpand;
            }
        }
    }

    public enum StrokeType
    {
        Solid,
        Dotted,
        Dashed
    }

    public enum SeparatorOrientation
    {
        Vertical,
        Horizontal
    }
}