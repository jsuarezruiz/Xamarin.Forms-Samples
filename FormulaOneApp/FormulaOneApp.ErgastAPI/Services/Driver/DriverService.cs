namespace FormulaOneApp.ErgastAPI.Services.Driver
{
    using System;
    using System.Threading.Tasks;
    using System.Net;
    using Model.Driver;
    using Model.Race;
    using Newtonsoft.Json;
    using Base;

    public class DriverService : HttpWebBase, IDriverService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        public async Task<DriverTable> GetDriverCollectionAsync(string season = "current")
        {
            RaceRootObject data = null;
            var url = string.Format("http://ergast.com/api/f1/{0}/drivers.json", season);

            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                data = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return data != null ? data.MRData.DriverTable : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public async Task<DriverTable> GetDriverInformationAsync(string driver = "")
        {
            RaceRootObject data = null;
            var url = string.Format("http://ergast.com/api/f1/drivers/{0}.json", driver);

            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                data = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return data != null ? data.MRData.DriverTable : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<DriverTable> GetChampionCollectionAsync()
        {
            RaceRootObject data = null;
            const string url = "http://ergast.com/api/f1/driverStandings/1/drivers.json";

            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                data = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return data != null ? data.MRData.DriverTable : null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="season"></param>
        /// <returns></returns>
        public async Task<RaceTable> GetDriverResultsAsync(string driver = "", string season = "current")
        {
            RaceRootObject data = null;
            string url = string.Format("http://ergast.com/api/f1/{0}/drivers/{1}/results.json", season, driver);

            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                data = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return data != null ? data.MRData.RaceTable : null;
        }
    }
}