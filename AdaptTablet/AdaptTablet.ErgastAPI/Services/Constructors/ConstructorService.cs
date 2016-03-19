namespace AdaptTablet.ErgastAPI.Services.Constructors
{
    using System;
    using System.Threading.Tasks;
    using System.Net;
    using Model.Constructor;
    using Model.Race;
    using Newtonsoft.Json;
    using Base;

    public class ConstructorService : HttpWebBase, IConstructorService
    {
        public async Task<ConstructorTable> GetSeasonConstructorCollectionAsync(string season = "current")
        {
            RaceRootObject data = null;
            var url = string.Format("http://ergast.com/api/f1/{0}/constructors.json", season);

            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                data = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return data != null ? data.MRData.ConstructorTable : null;
        }

        public async Task<ConstructorTable> GetAllConstructorCollectionAsync()
        {
            RaceRootObject data = null;
            const string url = "http://ergast.com/api/f1/constructors.json";
            
            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                data = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return data != null ? data.MRData.ConstructorTable : null;
        }
    }
}
