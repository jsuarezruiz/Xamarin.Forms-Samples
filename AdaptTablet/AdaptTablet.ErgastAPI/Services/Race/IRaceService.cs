namespace AdaptTablet.ErgastAPI.Services.Race
{
    using System.Threading.Tasks;
    using Model.Race;

    public interface IRaceService
    {        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        Task<RaceTable> GetSeasonScheduleCollectionAsync(string season = "current");
    }
}
