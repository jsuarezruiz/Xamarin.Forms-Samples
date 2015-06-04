namespace FormulaOneApp.ErgastAPI.Services.Driver
{
    using System.Threading.Tasks;
    using Model.Driver;
    using Model.Race;

    public interface IDriverService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        Task<DriverTable> GetDriverCollectionAsync(string season = "current");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        Task<DriverTable> GetDriverInformationAsync(string driver = "");

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<DriverTable> GetChampionCollectionAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        Task<RaceTable> GetDriverResultsAsync(string driver = "", string season = "current");
    }
}
