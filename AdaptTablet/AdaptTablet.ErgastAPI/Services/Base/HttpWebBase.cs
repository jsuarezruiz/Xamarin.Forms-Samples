using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AdaptTablet.ErgastAPI.Services.Base
{
    public class HttpWebBase
    {
        public async Task<string> HttpRequest(HttpWebRequest request)
        {
            string received;

            using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(responseStream))
                    {

                        received = await sr.ReadToEndAsync();
                    }
                }
            }

            return received;
        }
    }
}
