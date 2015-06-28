using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Android.Content;
using DependencyServiceSample.Droid.Services.Call;
using DependencyServiceSample.Services.Call;
using Xamarin.Forms;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(CallService))]
namespace DependencyServiceSample.Droid.Services.Call
{
    public class CallService : ICallService
    {
        public static void Init()
        {

        }

        public void MakeCall(string phone)
        {
            if (Regex.IsMatch(phone, "^(\\(?\\+?[0-9]*\\)?)?[0-9_\\- \\(\\)]*$"))
            {
                var uri = Uri.Parse(String.Format("tel:{0}", phone));
                var intent = new Intent(Intent.ActionView, uri);
                Forms.Context.StartActivity(intent);
            }
            else
            {
                Debug.WriteLine("Invalid number!");
            }
        }
    }
}