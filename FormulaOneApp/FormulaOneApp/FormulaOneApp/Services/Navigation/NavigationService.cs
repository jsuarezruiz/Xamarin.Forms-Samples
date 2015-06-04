namespace FormulaOneApp.Services.Navigation
{
    using System;
    using System.Collections.Generic;
    using ViewModels;
    using Views;
    using Xamarin.Forms;

    public class NavigationService : INavigationService
    {
        /// <summary>
        /// 
        /// </summary>
        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(MainViewModel), typeof(MainView) },
            { typeof(CircuitListViewModel), typeof(CircuitListView) },     
            { typeof(CircuitDetailViewModel), typeof(CircuitDetailView) },
            { typeof(DriverListViewModel), typeof(DriverListView) },
            { typeof(DriverDetailViewModel), typeof(DriverDetailView) },
            { typeof(StandingsViewModel), typeof(StandingsView) }
        };

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDestinationViewModel"></typeparam>
        /// <param name="navigationContext"></param>
        public void NavigateTo<TDestinationViewModel>(object navigationContext = null)
        {
            Type pageType = viewModelRouting[typeof(TDestinationViewModel)];
            var page = Activator.CreateInstance(pageType, navigationContext) as Page;
            Application.Current.MainPage.Navigation.PushAsync(page);
        }

        /// <summary>
        /// 
        /// </summary>
        public void NavigateBack()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public void NavigateBackToFirst()
        {
            Application.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}