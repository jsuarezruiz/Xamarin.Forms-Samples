using System.Net;
using SystemConfiguration;
using FormulaOneApp.iOS.Services.Internet;
using FormulaOneApp.Services.Internet;
using Xamarin.Forms;

[assembly: Dependency(typeof(InternetService))]
namespace FormulaOneApp.iOS.Services.Internet
{
    public class InternetService : IInternetService
    {
        private static NetworkReachability _defaultRoute;

        public InternetService()
        {
            _defaultRoute = new NetworkReachability(new IPAddress(0));
        }

        public bool HasConnection()
        {
            NetworkReachabilityFlags flags;
            _defaultRoute.TryGetFlags(out flags);

            return flags.HasFlag(NetworkReachabilityFlags.Reachable);
        }
    }
}