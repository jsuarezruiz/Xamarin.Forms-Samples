using System;
using System.Threading;
using XamarinForms_MarkupExtensions.iOS.Services.Localize;
using XamarinForms_MarkupExtensions.Services.Localize;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalizeService))]
namespace XamarinForms_MarkupExtensions.iOS.Services.Localize
{
    public class LocalizeService : ILocalizeService
    {
        public void SetLocale()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var netLocale = iosLocaleAuto.Replace("_", "-");
            System.Globalization.CultureInfo ci;

            try
            {
                ci = new System.Globalization.CultureInfo(netLocale);
            }
            catch
            {
                ci = GetCurrentCultureInfo();
            }

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Console.WriteLine("SetLocale: " + ci.Name);
        }

        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;
            Console.WriteLine("nslocaleid:" + iosLocaleAuto);
            Console.WriteLine("nslanguage:" + iosLanguageAuto);

            var iosLocale = NSLocale.CurrentLocale.LocaleIdentifier;
            var iosLanguage = NSLocale.CurrentLocale.LanguageCode;

            var netLocale = iosLocale.Replace("_", "-");
            var netLanguage = iosLanguage.Replace("_", "-");

            Console.WriteLine("ios:" + iosLanguage + " " + iosLocale);
            Console.WriteLine("net:" + netLanguage + " " + netLocale);

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-");
                Console.WriteLine("preferred:" + netLanguage);
            }

            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}