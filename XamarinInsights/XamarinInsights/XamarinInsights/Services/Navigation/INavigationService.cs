namespace XamarinInsights.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDestinationViewModel"></typeparam>
        /// <param name="navigationContext"></param>
        void NavigateTo<TDestinationViewModel>(object navigationContext = null);

        /// <summary>
        /// 
        /// </summary>
        void NavigateBack();

        /// <summary>
        /// 
        /// </summary>
        void NavigateBackToFirst();
    }
}
