using System.Diagnostics;
using System.Text.RegularExpressions;
using DependencyServiceSample.iOS.Services.Call;
using DependencyServiceSample.Services.Call;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(CallService))]
namespace DependencyServiceSample.iOS.Services.Call
{
    public class CallService : ICallService
    {
        public static void Init() { }

        public void MakeCall(string phone)
        {
            if (Regex.IsMatch(phone, "^(\\(?\\+?[0-9]*\\)?)?[0-9_\\- \\(\\)]*$"))
            {
                var url = new NSUrl(string.Format(@"telprompt://{0}", phone));
                UIApplication.SharedApplication.OpenUrl(url);
            }
            else
            {
                Debug.WriteLine("Invalid phone number!");
            }
        }
    }
}