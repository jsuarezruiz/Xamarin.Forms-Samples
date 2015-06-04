using Windows.UI.Xaml.Media.Animation;

namespace FormulaOneApp.Classic.Windows.Controls.Tile.Animations
{
    public interface ITileAnimation
    {
        Storyboard GetStoryboard(Tile tile);
    }
}
