using Android.App;
using Android.Content;
using Android.Net;
using FormulaOneApp.Classic.Core.Services.Internet;

namespace FormulaOneApp.Classic.Android.Services
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