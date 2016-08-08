namespace XamarinForms_MarkupExtensions.Services.Localize
{
    using System.Globalization;

    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale();
    }
}
