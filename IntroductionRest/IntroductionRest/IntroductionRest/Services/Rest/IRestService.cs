using System.Threading.Tasks;
using static IntroductionRest.Services.Rest.RestService;

namespace IntroductionRest.Services.Rest
{
    public interface IRestService
    {
        Task<string> GetRestServiceData(RestServiceType restServiceType);
    }
}
