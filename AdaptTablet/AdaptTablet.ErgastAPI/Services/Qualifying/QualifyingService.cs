namespace AdaptTablet.ErgastAPI.Services.Qualifying
{
    using System;
    using System.Threading.Tasks;
    using System.Net;
    using Model.Race;
    using Newtonsoft.Json;
    using Base;

    public class QualifyingService : HttpWebBase, IQualifyingService
    {
        public async Task<RaceTable> GetQualifyingResultAsync(string season = "current", int round = 1)
        {
            RaceRootObject data = null;

            var url = string.Format("http://ergast.com/api/f1/{0}/{1}/qualifying.json", season, round);
            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                data = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return data != null ? data.MRData.RaceTable : null;
        }
    }
}