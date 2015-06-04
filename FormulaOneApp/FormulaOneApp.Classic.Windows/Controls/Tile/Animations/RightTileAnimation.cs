using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace FormulaOneApp.Classic.Windows.Controls.Tile.Animations
{
    public class RightTileAnimation : ITileAnimation
    {
        public Storyboard GetStoryboard(Tile tile)
        {
            var storyboard = new Storyboard();

            var animDuration = new Duration(TimeSpan.FromMilliseconds(1000d));
            var offset = tile.BorderThickness.Right + tile.BorderThickness.Left;
            var end = tile.ActualWidth - offset;
            var start = 0d;

            if (tile.IsFrontSide)
            {

                storyboard.AddToStoryboard(start, -end, animDuration,
                             tile.FrontContentPresenter,
                             "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

                storyboard.AddToStoryboard(end, start, animDuration,
                              tile.BackContentPresenter,
                              "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

                storyboard.Completed += (sender1, o1) =>
                {
                    tile.FrontContentPresenter.Visibility = Visibility.Collapsed;
                    tile.IsFrontSide = false;
                };

            }
            else
            {

                storyboard.AddToStoryboard(start, -end, animDuration,
                             tile.BackContentPresenter,
                             "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");

                storyboard.AddToStoryboard(end, start, animDuration,
                              tile.FrontContentPresenter,
                              "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");


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
