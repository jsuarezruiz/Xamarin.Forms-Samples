using System;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using FormulaOneApp.Classic.Windows.Controls.Tile.Animations;

namespace FormulaOneApp.Classic.Windows.Controls.Tile
{
    [TemplatePart(Name = "PART_FrontContentPresenter", Type = typeof(Tile))]
    [TemplatePart(Name = "PART_BackContentPresenter", Type = typeof(Tile))]
    [TemplatePart(Name = "PART_OverlayContentPresenter", Type = typeof(Tile))]
    public class Tile : Control
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(Tile), new PropertyMetadata(null));

        public Object CommandParameter
        {
            get { return (Object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(Object), typeof(Tile), new PropertyMetadata(null));


        private DispatcherTimer dispatcherTimer;
        public ContentPresenter FrontContentPresenter { get; private set; }
        public ContentPresenter BackContentPresenter { get; private set; }
        private Random random;

        //public TileAnimation TileAnimation { get; set; }
        public Boolean IsFrontSide { get; set; }

        public Tile()
        {
            this.DefaultStyleKey = typeof(Tile);
            this.IsFrontSide = true;
            var rnd = new Random();
            Int32 generateNumber = (Int32) rnd.Next(1, 9999);
            random = new Random(generateNumber);

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(random.Next(3, 10));
            dispatcherTimer.Tick += DispatcherTimerOnTick;

            if (!this.IsAnimationEnabled)
                dispatcherTimer.Start();

        }

        private void DispatcherTimerOnTick(object sender, object o)
        {
            dispatcherTimer.Interval = TimeSpan.FromSeconds(random.Next(6, 10));


            if (this.TileAnimation == null)
            {
                dispatcherTimer.Stop();
                return;
            }

            Storyboard sb = this.TileAnimation.GetStoryboard(this);

            sb.Begin();

        }

        public Boolean IsAnimationEnabled
        {
            get { return (Boolean)GetValue(IsAnimationEnabledProperty); }
            set { SetValue(IsAnimationEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isAnimationEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAnimationEnabledProperty =
            DependencyProperty.Register("IsAnimationEnabled", typeof(Boolean), typeof(Tile), new PropertyMetadata(true, OnAnimationEnabledChanged));

        private static void OnAnimationEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Tile tile = (Tile)d;
            Boolean isAnimationEnabled = (Boolean)e.NewValue;
            Boolean oldValue = (Boolean)e.OldValue;

            if (isAnimationEnabled == oldValue)
                return;

            if (isAnimationEnabled && !tile.dispatcherTimer.IsEnabled)
                tile.dispatcherTimer.Start();

            if (!isAnimationEnabled && tile.dispatcherTimer.IsEnabled)
                tile.dispatcherTimer.Stop();
        }



        public Object OverlayContent
        {
            get { return GetValue(OverlayContentProperty); }
            set { SetValue(OverlayContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OverlayContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OverlayContentProperty =
            DependencyProperty.Register("OverlayContent", typeof(Object), typeof(Tile), new PropertyMetadata(null));

        public Object FrontContent
        {
            get { return GetValue(FrontContentProperty); }
            set { SetValue(FrontContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FrontContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrontContentProperty =
            DependencyProperty.Register("FrontContent", typeof(Object), typeof(Tile), new PropertyMetadata(null));


        public Object BackContent
        {
            get { return GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackContentProperty =
            DependencyProperty.Register("BackContent", typeof(Object), typeof(Tile), new PropertyMetadata(null));

        public ITileAnimation TileAnimation
        {
            get { return (ITileAnimation)GetValue(TileAnimationProperty); }
            set { SetValue(TileAnimationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TileAnimation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TileAnimationProperty =
            DependencyProperty.Register("TileAnimation", typeof(ITileAnimation),
                                                         typeof(Tile),
                                                         new PropertyMetadata(new UpAndDownTileAnimation()));



        protected override void OnApplyTemplate()
        {

            FrontContentPresenter = this.GetTemplateChild("PART_FrontContentPresenter") as ContentPresenter;
            BackContentPresenter = this.GetTemplateChild("PART_BackContentPresenter") as ContentPresenter;

            if (this.FrontContentPresenter != null)
                this.SetPlaneProjection(this.FrontContentPresenter);

            if (this.BackContentPresenter != null)
                this.SetPlaneProjection(this.BackContentPresenter);


        }


        protected override void OnTapped(TappedRoutedEventArgs e)
        {
            base.OnTapped(e);
            ExecuteCommand();
        }

        internal void ExecuteCommand()
        {
            if (this.Command == null) return;
            if (this.Command.CanExecute(this.CommandParameter))
                this.Command.Execute(this.CommandParameter);
        }

        private void AnimateRotationVertical()
        {
            var animDuration = new Duration(TimeSpan.FromMilliseconds(1000d));

            var storyboard = new Storyboard();

            var animationSnapFront = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = 0,
                To = 180,
                Duration = animDuration,
                EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseOut, Exponent = 8d }
            };

            var animationSnapFrontOpacity = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromMilliseconds(50d),
                Duration = new Duration(TimeSpan.FromMilliseconds(1d))
            };

            storyboard.Children.Add(animationSnapFront);
            storyboard.Children.Add(animationSnapFrontOpacity);

            Storyboard.SetTarget(animationSnapFront, this.IsFrontSide ? this.FrontContentPresenter : this.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapFront, "(UIElement.Projection).(PlaneProjection.RotationX)");

            Storyboard.SetTarget(animationSnapFrontOpacity, this.IsFrontSide ? this.FrontContentPresenter : this.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapFrontOpacity, "Opacity");

            var animationSnapBack = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = 180,
                To = 0,
                Duration = animDuration,
                EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseOut, Exponent = 8d }
            };

            var animationSnapBackOpacity = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = 0,
                To = 1,
                BeginTime = TimeSpan.FromMilliseconds(50d),
                Duration = new Duration(TimeSpan.FromMilliseconds(1d))
            };


            storyboard.Children.Add(animationSnapBack);
            storyboard.Children.Add(animationSnapBackOpacity);

            Storyboard.SetTarget(animationSnapBack, !this.IsFrontSide ? this.FrontContentPresenter : this.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapBack, "(UIElement.Projection).(PlaneProjection.RotationX)");

            Storyboard.SetTarget(animationSnapBackOpacity, !this.IsFrontSide ? this.FrontContentPresenter : this.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapBackOpacity, "Opacity");

            this.IsFrontSide = !this.IsFrontSide;

            storyboard.Begin();

        }


        private void AnimateRotationHorizontal()
        {
            var animDuration = new Duration(TimeSpan.FromMilliseconds(1000d));

            var storyboard = new Storyboard();

            var animationSnapFront = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = 0,
                To = 180,
                Duration = animDuration,
                EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseOut, Exponent = 8d }
            };

            var animationSnapFrontOpacity = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromMilliseconds(50d),
                Duration = new Duration(TimeSpan.FromMilliseconds(1d))
            };

            storyboard.Children.Add(animationSnapFront);
            storyboard.Children.Add(animationSnapFrontOpacity);

            Storyboard.SetTarget(animationSnapFront, this.IsFrontSide ? this.FrontContentPresenter : this.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapFront, "(UIElement.Projection).(PlaneProjection.RotationY)");

            Storyboard.SetTarget(animationSnapFrontOpacity, this.IsFrontSide ? this.FrontContentPresenter : this.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapFrontOpacity, "Opacity");

            var animationSnapBack = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = 180,
                To = 0,
                Duration = animDuration,
                EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseOut, Exponent = 8d }
            };

            var animationSnapBackOpacity = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                From = 0,
                To = 1,
                BeginTime = TimeSpan.FromMilliseconds(50d),
                Duration = new Duration(TimeSpan.FromMilliseconds(1d))
            };


            storyboard.Children.Add(animationSnapBack);
            storyboard.Children.Add(animationSnapBackOpacity);

            Storyboard.SetTarget(animationSnapBack, !this.IsFrontSide ? this.FrontContentPresenter : this.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapBack, "(UIElement.Projection).(PlaneProjection.RotationY)");

            Storyboard.SetTarget(animationSnapBackOpacity, !this.IsFrontSide ? this.FrontContentPresenter : this.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapBackOpacity, "Opacity");

            this.IsFrontSide = !this.IsFrontSide;

            storyboard.Begin();

        }



        //private void AnimateLeft()
        //{

        //    var animDuration = new Duration(TimeSpan.FromMilliseconds(1000d));
        //    var offset = this.BorderThickness.Right + this.BorderThickness.Left;

        //    if (this.IsFrontSide)
        //    {
        //        var storyboard = new Storyboard();

        //        storyboard = this.AddToStoryboard(storyboard, -this.ActualWidth + offset, 0d, animDuration,
        //                    this.backContentPresenter,
        //                    "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

        //        storyboard = this.AddToStoryboard(storyboard, 0d, this.ActualWidth - offset, animDuration,
        //                      this.frontContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

        //        this.IsFrontSide = false;

        //        storyboard.Begin();

        //    }
        //    else
        //    {
        //        var storyboard = new Storyboard();

        //        storyboard = this.AddToStoryboard(storyboard, -this.ActualWidth + offset, 0d, animDuration,
        //                     this.frontContentPresenter,
        //                     "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

        //        storyboard = this.AddToStoryboard(storyboard, 0d, this.ActualWidth - offset, animDuration,
        //                      this.backContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");


        //        storyboard.Begin();
        //        this.IsFrontSide = true;
        //    }
        //}


        //private void AnimateRight()
        //{

        //    var animDuration = new Duration(TimeSpan.FromMilliseconds(1000d));
        //    var offset = this.BorderThickness.Right + this.BorderThickness.Left;

        //    if (this.IsFrontSide)
        //    {
        //        var storyboard = new Storyboard();

        //        storyboard = this.AddToStoryboard(storyboard, 0d, -this.ActualWidth + offset, animDuration,
        //                     this.frontContentPresenter,
        //                     "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

        //        storyboard = this.AddToStoryboard(storyboard, this.ActualWidth - offset, 0d, animDuration,
        //                      this.backContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

        //        this.IsFrontSide = false;

        //        storyboard.Begin();

        //    }
        //    else
        //    {
        //        var storyboard = new Storyboard();

        //        storyboard = this.AddToStoryboard(storyboard, 0d, -this.ActualWidth + offset, animDuration,
        //                    this.backContentPresenter,
        //                    "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

        //        storyboard = this.AddToStoryboard(storyboard, this.ActualWidth - offset, 0d, animDuration,
        //                      this.frontContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");


        //        storyboard.Begin();
        //        this.IsFrontSide = true;
        //    }
        //}


        //private void AnimateUp()
        //{

        //    var animDuration = new Duration(TimeSpan.FromMilliseconds(1000d));
        //    var offset = this.BorderThickness.Top + this.BorderThickness.Bottom;

        //    if (this.IsFrontSide)
        //    {
        //        var storyboard = new Storyboard();
        //        this.backContentPresenter.Visibility = Visibility.Visible;


        //        storyboard = this.AddToStoryboard(storyboard, 0d, -this.ActualHeight + offset, animDuration,
        //                     this.frontContentPresenter,
        //                     "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

        //        storyboard = this.AddToStoryboard(storyboard, this.ActualHeight - offset, 0d, animDuration,
        //                      this.backContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

        //        storyboard.Completed += (sender1, o1) => this.frontContentPresenter.Visibility = Visibility.Collapsed;

        //        this.IsFrontSide = false;

        //        storyboard.Begin();

        //    }
        //    else
        //    {
        //        var storyboard = new Storyboard();
        //        this.frontContentPresenter.Visibility = Visibility.Visible;

        //        storyboard = this.AddToStoryboard(storyboard, 0d, -this.ActualHeight + offset, animDuration,
        //                      this.backContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

        //        storyboard = this.AddToStoryboard(storyboard, this.ActualHeight - offset, 0d, animDuration,
        //                      this.frontContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

        //        storyboard.Completed += (sender1, o1) => this.backContentPresenter.Visibility = Visibility.Collapsed;

        //        storyboard.Begin();
        //        this.IsFrontSide = true;
        //    }
        //}

        //private void AnimateDown()
        //{

        //    var animDuration = new Duration(TimeSpan.FromMilliseconds(1000d));
        //    var offset = this.BorderThickness.Top + this.BorderThickness.Bottom;

        //    if (this.IsFrontSide)
        //    {
        //        var storyboard = new Storyboard();
        //        this.backContentPresenter.Visibility = Visibility.Visible;


        //        storyboard = this.AddToStoryboard(storyboard, -this.ActualHeight + offset, 0d, animDuration,
        //                      this.backContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

        //        storyboard = this.AddToStoryboard(storyboard, 0d, this.ActualHeight - offset, animDuration,
        //                      this.frontContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");


        //        storyboard.Completed += (sender1, o1) => this.frontContentPresenter.Visibility = Visibility.Collapsed;

        //        this.IsFrontSide = false;

        //        storyboard.Begin();

        //    }
        //    else
        //    {
        //        var storyboard = new Storyboard();
        //        this.frontContentPresenter.Visibility = Visibility.Visible;

        //        storyboard = this.AddToStoryboard(storyboard, -this.ActualHeight + offset, 0d, animDuration,
        //                      this.frontContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

        //        storyboard = this.AddToStoryboard(storyboard, 0d, this.ActualHeight - offset, animDuration,
        //                      this.backContentPresenter,
        //                      "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");


        //        storyboard.Completed += (sender1, o1) => this.backContentPresenter.Visibility = Visibility.Collapsed;

        //        storyboard.Begin();
        //        this.IsFrontSide = true;
        //    }
        //}


        private void SetPlaneProjection(UIElement contentGrid)
        {
            PlaneProjection planeProjection = new PlaneProjection();
            contentGrid.Projection = planeProjection;

        }



        private void ChangeBackGroundImage(ImageSource source, Grid contentGrid)
        {
            ImageBrush backGroundImage = new ImageBrush();
            backGroundImage.Stretch = Stretch.Fill;
            backGroundImage.ImageSource = source;
            contentGrid.Background = backGroundImage;
        }


        protected override Size MeasureOverride(Size availableSize)
        {
            // Clip to ensure items dont override container

            var size = base.MeasureOverride(availableSize);
            this.Clip = new RectangleGeometry { Rect = new Rect(0, 0, size.Width, size.Height) };

            return size;

        }



    }

    //public enum TileAnimation
    //{
    //    UpAndDown,
    //    Up,
    //    Down,
    //    LeftToRight,
    //    RightToLeft,
    //    Left,
    //    Right,
    //    RotationHorizontal,
    //    RotationVertical,
    //}
}