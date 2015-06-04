namespace FormulaOneApp.ErgastAPI.Services.Circuits
{
    using System.Threading.Tasks;
    using Model.Circuit;

    public interface ICircuitService
    {        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        Task<CircuitTable> GetSeasonCircuitsCollectionAsync(string season = "current");

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<CircuitTable> GetAllCircuitsCollectionAsync();
    }
}
