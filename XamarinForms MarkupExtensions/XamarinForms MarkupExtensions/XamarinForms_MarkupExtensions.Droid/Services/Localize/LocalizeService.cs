using System;
using System.Threading;
using XamarinForms_MarkupExtensions.Services.Localize;
using Xamarin.Forms;
using XamarinForms_MarkupExtensions.Droid.Services.Localize;

[assembly: Dependency(typeof(LocalizeService))]
namespace XamarinForms_MarkupExtensions.Droid.Services.Localize
{
    public class LocalizeService : ILocalizeService
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");

            Console.WriteLine("android:" + androidLocale);
            Console.WriteLine("net:" + netLanguage);

            Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            Console.WriteLine(Thread.CurrentThread.CurrentUICulture);

            return new System.Globalization.CultureInfo(netLanguage);
        }

        public void SetLocale()
        {
            var androidLocale = Java.Util.Locale.Default; 
            var netLocale = androidLocale.ToString().Replace("_", "-");
            var ci = new System.Globalization.CultureInfo(netLocale);

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}