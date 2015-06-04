using Windows.Networking.Connectivity;
using FormulaOneApp.Services.Internet;
using FormulaOneApp.WinPhone.Services.Internet;
using Xamarin.Forms;

[assembly: Dependency(typeof(InternetService))]
namespace FormulaOneApp.WinPhone.Services.Internet
{
    public class InternetService : IInternetService
    {
        public bool HasConnection()
        {
            return NetworkInformation.GetInternetConnectionProfile() != null;
        }
    }
}
