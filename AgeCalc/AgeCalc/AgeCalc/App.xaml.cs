using AgeCalc.ViewModels.Base;
using AgeCalc.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgeCalc
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class App : Application
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator = _locator ?? new ViewModelLocator();
            }
        }

        public static DateTime MinimumDate = DateTime.Parse("Jan 1 1900");
        public static DateTime MaximumDate = DateTime.Parse("Dec 31 2015");

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainView());
            MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}
