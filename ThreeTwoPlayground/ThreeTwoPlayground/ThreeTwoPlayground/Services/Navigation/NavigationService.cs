using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTwoPlayground.ViewModels;
using ThreeTwoPlayground.ViewModels.Base;
using ThreeTwoPlayground.Views;
using Xamarin.Forms;

namespace ThreeTwoPlayground.Services.Navigation
{
    public partial class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get { return Application.Current; }
        }

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
            await NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (CurrentApplication.MainPage is CustomNavigationPage navigationPage)
            {
                await navigationPage.PushAsync(page);
            }
            else
            {
                CurrentApplication.MainPage = new CustomNavigationPage(page);
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new Exception($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = Locator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(ButtonPaddingsViewModel), typeof(ButtonPaddingsView));
            _mappings.Add(typeof(CommandableSpansViewModel), typeof(CommandableSpansView));
            _mappings.Add(typeof(EditorPlaceholderViewModel), typeof(EditorPlaceholderView));
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(OnPlatformMarkupExtensionsViewModel), typeof(OnPlatformMarkupExtensionsView));
            _mappings.Add(typeof(OthersViewModel), typeof(OthersView));
            _mappings.Add(typeof(PageTitleViewModel), typeof(PageTitleView));
            _mappings.Add(typeof(RoundedCornersBoxViewModel), typeof(RoundedCornersBoxView));
            _mappings.Add(typeof(SwipeGestureViewModel), typeof(SwipeGestureView));
        }
    }
}