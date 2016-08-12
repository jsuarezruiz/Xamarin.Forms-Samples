using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntroductionRest.Services.Rest
{
    public class RestService : IRestService
    {
        public enum RestServiceType
        {
            HttpClient,
            HttpWebRequest,
            RestSharp
        };

        public async Task<string> GetRestServiceData(RestServiceType restServiceType)
        {
            switch (restServiceType)
            {
                case RestServiceType.HttpClient:
                    return await GetHttpClientData();
                case RestServiceType.HttpWebRequest:
                    return await GetHttpWebData();
                case RestServiceType.RestSharp:
                    return await GetRestSharpData();
            }

            return string.Empty;
        }

        internal async Task<string> GetHttpClientData()
        {
            var season = "current";

            var uri = new Uri(string.Format(@"http://ergast.com/api/f1/{0}/driverStandings.json", season));
            var client = new HttpClient();
            var response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return string.Empty;
        }

        internal async Task<string> GetHttpWebData()
        {
            var season = "current";
            var request = HttpWebRequest.Create(string.Format(@"http://ergast.com/api/f1/{0}/driverStandings.json", season));
            request.ContentType = "application/json";
            request.Method = "GET";

            using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Debug.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);

                    return string.Empty;
                }

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();

                    if (string.IsNullOrWhiteSpace(content))
                    {
                        Debug.WriteLine("Response contained empty body...");
                    }
                    else
                    {
                        Debug.WriteLine("Response Body: \r\n {0}", content);
                    }

                    return content;
                }
            }
        }

        /// <summary>
        /// More info: https://github.com/FubarDevelopment/restsharp.portable
        /// </summary>
        /// <returns>Response content</returns>
        internal async Task<string> GetRestSharpData()
        {
            var season = "current";
        
            using (var client = new RestClient(string.Format(@"http://ergast.com/api/f1/{0}/driverStandings.json", season)))
            {
                var request = new RestRequest(Method.GET);
                var result = await client.Execute(request);

                return result.Content;
            }
        }
    }
}