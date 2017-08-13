using Microsoft.Azure.Mobile.Analytics;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileCenterCrashApp.Views
{
    public partial class ErrorView : ContentPage
    {
        public ErrorView()
        {
            InitializeComponent();

            EventBtn.Clicked += (sender, args) =>
            {
                var properties = new Dictionary<string, string>
                {
                     { "Parameter", "Data" }
                };

                Analytics.TrackEvent("EventBtn Clicked", properties);
            };

            ExceptionBtn.Clicked += (sender, args) =>
            {
                throw new Exception("Exception information");
            };
        }
    }
}