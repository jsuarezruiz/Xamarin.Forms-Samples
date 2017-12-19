using System;
using System.Diagnostics;
using Android.Content;
using XamarinForms_Services.Droid.Services.Call;
using XamarinForms_Services.Services.Call;
using Xamarin.Forms;

[assembly: Dependency(typeof(CallService))]
namespace XamarinForms_Services.Droid.Services.Call
{
    public class CallService : ICallService
    {
        public static void Init()
        {

        }

        public void MakeCall(string phone)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(phone, "^(\\(?\\+?[0-9]*\\)?)?[0-9_\\- \\(\\)]*$"))
            {
                var uri = Android.Net.Uri.Parse(String.Format("tel:{0}", phone));
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