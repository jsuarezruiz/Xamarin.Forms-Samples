namespace FormulaOneApp.ErgastAPI.Services.Standings
{
    using System.Threading.Tasks;
    using Model.Standing;

    /// <summary>
    /// 
    /// </summary>
    public interface IStandingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        Task<StandingTable> GetSeasonConstructorStandingsCollectionAsync(string season = "current");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        Task<StandingTable> GetSeasonDriverStandingsCollectionAsync(string season = "current");
    }
}
