namespace FormulaOneApp.ErgastAPI.Services.Constructors
{
    using System.Threading.Tasks;
    using Model.Constructor;

    public interface IConstructorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        Task<ConstructorTable> GetSeasonConstructorCollectionAsync(string season = "current");

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ConstructorTable> GetAllConstructorCollectionAsync();
    }
}
