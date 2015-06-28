using System.Diagnostics;
using DependencyServiceSample.Services.Call;
using DependencyServiceSample.WinPhone.Services.Call;
using Microsoft.Phone.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CallService))]
namespace DependencyServiceSample.WinPhone.Services.Call
{
    class CallService : ICallService
    {
        public static void Init() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        public void MakeCall(string phone)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(phone, "^(\\(?\\+?[0-9]*\\)?)?[0-9_\\- \\(\\)]*$"))
            {
                var phoneCallTask = new PhoneCallTask { PhoneNumber = phone };

                phoneCallTask.Show();
            }
            else
            {
                Debug.WriteLine("Invalid number!");
            }
        }
    }
}
