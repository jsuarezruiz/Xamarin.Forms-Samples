using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace FormulaOneApp.Classic.Windows.Controls.Tile.Animations
{
    public class RotationHorizontalTileAnimation : ITileAnimation
    {


        public Storyboard GetStoryboard(Tile tile)
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

            Storyboard.SetTarget(animationSnapFront, tile.IsFrontSide ? tile.FrontContentPresenter : tile.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapFront, "(UIElement.Projection).(PlaneProjection.RotationY)");

            Storyboard.SetTarget(animationSnapFrontOpacity, tile.IsFrontSide ? tile.FrontContentPresenter : tile.BackContentPresenter);
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

            Storyboard.SetTarget(animationSnapBack, !tile.IsFrontSide ? tile.FrontContentPresenter : tile.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapBack, "(UIElement.Projection).(PlaneProjection.RotationY)");

            Storyboard.SetTarget(animationSnapBackOpacity, !tile.IsFrontSide ? tile.FrontContentPresenter : tile.BackContentPresenter);
            Storyboard.SetTargetProperty(animationSnapBackOpacity, "Opacity");

            tile.IsFrontSide = !tile.IsFrontSide;

            return storyboard;

        }
    }
}
