namespace AdaptTablet.ErgastAPI.Services.Circuits
{
    using System;
    using System.Net;
    using Model.Circuit;
    using Model.Race;
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    using Model.Constructor;
    using Base;

    public class CircuitService : HttpWebBase, ICircuitService
    {
        public async Task<CircuitTable> GetSeasonCircuitsCollectionAsync(string season = "current")
        {
            RaceRootObject data = null;
            var url = string.Format("http://ergast.com/api/f1/{0}/circuits.json", season);

            HttpWebRequest request = WebRequest.CreateHttp(new Uri(url));
            var response = await HttpRequest(request);
            if (response != null)
                data = JsonConvert.DeserializeObject<RaceRootObject>(response);

            return data != null ? data.MRData.CircuitTable : null;
        }

        public Task<CircuitTable> GetAllCircuitsCollectionAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
