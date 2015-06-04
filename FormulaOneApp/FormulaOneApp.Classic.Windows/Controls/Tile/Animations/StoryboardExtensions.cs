using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace FormulaOneApp.Classic.Windows.Controls.Tile.Animations
{
    public static class StoryboardExtensions
    {
        public static Storyboard AddToStoryboard(this Storyboard storyboard, Double fromOffset, double toOffset,
                Duration animationDuration, DependencyObject target, string targetProperty, EasingFunctionBase easingFunction = null)
        {

            var animationSnap = new DoubleAnimation
            {
                
                EnableDependentAnimation = true,
                From = fromOffset,
                To = toOffset,
                Duration = animationDuration,
                EasingFunction = easingFunction ?? new ExponentialEase { EasingMode = EasingMode.EaseOut, Exponent = 8d }
            };

            storyboard.Children.Add(animationSnap);

            Storyboard.SetTarget(animationSnap, target);
            Storyboard.SetTargetProperty(animationSnap, targetProperty);

            return storyboard;
        }
    }
}
