using System.Windows.Input;
using ThreeOnePlayground.ViewModels.Base;
using Xamarin.Forms;

namespace ThreeOnePlayground.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand AutoResizeEditorCommand => new Command(AutoResizeEditor);
        public ICommand EntryAutoCapitalizationCommand => new Command(EntryAutoCapitalization);
        public ICommand EntryReturnKeyCommand => new Command(EntryReturnKey);
        public ICommand EvaluateJsCommand => new Command(EvaluateJs);
        public ICommand TabsCommand => new Command(Tabs);
        public ICommand OthersCommand => new Command(Others);

        private void AutoResizeEditor()
        {
            NavigationService.NavigateToAsync<AutoResizeEditorViewModel>();
        }

        private void EntryAutoCapitalization()
        {
            NavigationService.NavigateToAsync<EntryAutoCapitalizationViewModel>();
        }

        private void EntryReturnKey()
        {
            NavigationService.NavigateToAsync<EntryReturnKeyViewModel>();
        }

        private void EvaluateJs()
        {
            NavigationService.NavigateToAsync<EvaluateJavaScriptViewModel>();
        }

        private void Tabs()
        {
            NavigationService.NavigateToAsync<TabsViewModel>();
        }

        private void Others()
        {
            NavigationService.NavigateToAsync<OthersViewModel>();
        }
    }
}