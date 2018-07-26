using System.Windows.Input;
using ThreeTwoPlayground.ViewModels.Base;
using Xamarin.Forms;

namespace ThreeTwoPlayground.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ButtonPaddingsCommand => new Command(ButtonPaddings);
        public ICommand CommandableSpansCommand => new Command(CommandableSpans);
        public ICommand EditorPlaceholderCommand => new Command(EditorPlaceholder);
        public ICommand OnPlatformMarkupExtensionsCommand => new Command(OnPlatformMarkupExtensions);
        public ICommand PageTitleCommand => new Command(PageTitle);
        public ICommand RoundedCornersBoxCommand => new Command(RoundedCornersBox);
        public ICommand SwipeGestureCommand => new Command(SwipeGesture);
        public ICommand OthersCommand => new Command(Others);

        private void ButtonPaddings()
        {
            NavigationService.NavigateToAsync<ButtonPaddingsViewModel>();
        }

        private void CommandableSpans()
        {
            NavigationService.NavigateToAsync<CommandableSpansViewModel>();
        }

        private void EditorPlaceholder()
        {
            NavigationService.NavigateToAsync<EditorPlaceholderViewModel>();
        }

        private void OnPlatformMarkupExtensions()
        {
            NavigationService.NavigateToAsync<OnPlatformMarkupExtensionsViewModel>();
        }

        private void PageTitle()
        {
            NavigationService.NavigateToAsync<PageTitleViewModel>();
        }

        private void RoundedCornersBox()
        {
            NavigationService.NavigateToAsync<RoundedCornersBoxViewModel>();
        }

        private void SwipeGesture()
        {
            NavigationService.NavigateToAsync<SwipeGestureViewModel>();
        }

        private void Others()
        {
            NavigationService.NavigateToAsync<OthersViewModel>();
        }
    }
}