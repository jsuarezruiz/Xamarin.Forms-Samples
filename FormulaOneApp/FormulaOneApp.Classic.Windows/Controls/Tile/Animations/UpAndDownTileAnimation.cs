using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace FormulaOneApp.Classic.Windows.Controls.Tile.Animations
{
    public class UpAndDownTileAnimation : ITileAnimation
    {
        /// <summary>
        /// Get Up and Down Storyboard
        /// </summary>
        public Storyboard GetStoryboard(Tile tile)
        {
            var storyboard = new Storyboard();
            var animDuration = new Duration(TimeSpan.FromMilliseconds(1000d));
            var offset = tile.BorderThickness.Top + tile.BorderThickness.Bottom;
            var start = 0d;
            var end = tile.ActualHeight - offset;

            if (tile.IsFrontSide)
            {
                tile.BackContentPresenter.Visibility = Visibility.Visible;


                storyboard.AddToStoryboard(start, -end, animDuration,
                             tile.FrontContentPresenter,
                             "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

                storyboard.AddToStoryboard(end, start, animDuration,
                              tile.BackContentPresenter,
                              "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

                storyboard.Completed += (sender1, o1) =>
                    {
                        tile.FrontContentPresenter.Visibility = Visibility.Collapsed;
                        tile.IsFrontSide = false;
                    };

            }
            else
            {
                tile.FrontContentPresenter.Visibility = Visibility.Visible;

                storyboard.AddToStoryboard(-end, start, animDuration,
                             tile.FrontContentPresenter,
                             "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

                storyboard.AddToStoryboard(start, end, animDuration,
                              tile.BackContentPresenter,
                              "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");

                storyboard.Completed += (sender1, o1) =>
                    {
                        tile.BackContentPresenter.Visibility = Visibility.Collapsed;
                        tile.IsFrontSide = true;
                    };

            }

            return storyboard;
        }

    }
}
