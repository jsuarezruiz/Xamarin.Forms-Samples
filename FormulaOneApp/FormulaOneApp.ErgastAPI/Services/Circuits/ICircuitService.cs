namespace FormulaOneApp.ErgastAPI.Services.Circuits
{
    using System.Threading.Tasks;
    using Model.Constructor;

    public interface ICircuitService
    {        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        Task<ConstructorTable> GetSeasonCircuitsCollectionAsync(string season = "current");

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ConstructorTable> GetAllCircuitsCollectionAsync();
    }
}
