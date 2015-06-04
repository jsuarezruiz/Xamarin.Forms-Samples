using Windows.Networking.Connectivity;
using FormulaOneApp.Classic.Core.Services.Internet;

namespace FormulaOneApp.Classic.Windows.Services.Internet
{
    public class InternetService : IInternetService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasConnection()
        {
            return NetworkInformation.GetInternetConnectionProfile() != null;
        }
    }
}
