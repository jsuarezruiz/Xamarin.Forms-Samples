namespace IntroductionRest.Services.Navigation
{
    using System;
    using System.Collections.Generic;
    using ViewModels;
    using Views;
    using Xamarin.Forms;

    public class NavigationService : INavigationService
    {
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(MainViewModel),  typeof(MainView) },
            { typeof(HttpClientViewModel), typeof(HttpClientView) },
            { typeof(HttpWebRequestViewModel), typeof(HTTPWebRequestView) },
            { typeof(RestSharpViewModel), typeof(RestSharpView) }
        };

        public void NavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void NavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;

            if (page != null)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void NavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}