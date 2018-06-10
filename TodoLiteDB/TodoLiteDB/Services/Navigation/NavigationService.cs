using System;
using System.Collections.Generic;
using TodoLiteDB.ViewModels;
using TodoLiteDB.Views;
using Xamarin.Forms;

namespace TodoLiteDB.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(TodoListViewModel),  typeof(TodoListView) },
            { typeof(TodoItemViewModel), typeof(TodoItemView) }
        };

        public void NavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];

            if (Activator.CreateInstance(pageType, navigationContext) is Page page)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void NavigateTo(Type destinationType, object navigationContext = null)
        {
            Type pageType = viewModelRouting[destinationType];

            if (Activator.CreateInstance(pageType, navigationContext) is Page page)
                Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public void NavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}