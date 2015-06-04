using Android.App;
using Android.Content;
using Android.Net;
using FormulaOneApp.Droid.Services.Internet;
using FormulaOneApp.Services.Internet;
using Xamarin.Forms;

[assembly: Dependency(typeof(InternetService))]
namespace FormulaOneApp.Droid.Services.Internet
{
    public class InternetService : IInternetService
    {
        public bool HasConnection()
        {   
            var connectivityManager = (ConnectivityManager)
            Application.Context.GetSystemService(Context.ConnectivityService);
            var activeConnection = connectivityManager.ActiveNetworkInfo;
            return (activeConnection != null) && activeConnection.IsConnected;
        }
    }
}