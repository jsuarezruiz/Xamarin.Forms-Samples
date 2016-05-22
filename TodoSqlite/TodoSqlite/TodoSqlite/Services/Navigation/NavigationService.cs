namespace TodoSqlite.Services.Navigation
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
            { typeof(TodoListViewModel),  typeof(TodoListView) },
            { typeof(TodoItemViewModel), typeof(TodoItemView) }
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