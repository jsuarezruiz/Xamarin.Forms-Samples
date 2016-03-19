namespace AdaptTablet.ErgastAPI.Services.Race
{
    using System.Threading.Tasks;
    using System;
    using System.Net;
    using Model.Race;
    using Newtonsoft.Json;
    using Base;

    public class RaceService : HttpWebBase, IRaceService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        public async Task<RaceTable> GetSeasonScheduleCollectionAsync(string season = "current")
        {
            RaceRootObject result = null;

            var url = string.Format("http://ergast.com/api/f1/{0}.json", season);
            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                result = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return result != null ? result.MRData.RaceTable : null;
        }
    }
}
