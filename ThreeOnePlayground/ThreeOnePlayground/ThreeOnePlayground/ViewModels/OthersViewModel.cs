using ThreeOnePlayground.ViewModels.Base;

namespace ThreeOnePlayground.ViewModels
{
    public class OthersViewModel : ViewModelBase
    {
        public OthersViewModel()
        {
            Info = " Binding ";
        }

        public string Info { get; set; }
    }
}