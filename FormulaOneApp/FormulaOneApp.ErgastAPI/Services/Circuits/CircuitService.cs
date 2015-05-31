namespace FormulaOneApp.ErgastAPI.Services.Circuits
{
    using System.Threading.Tasks;
    using Model.Constructor;
    using Base;

    public class CircuitService : HttpWebBase, ICircuitService
    {
        public Task<ConstructorTable> GetSeasonCircuitsCollectionAsync(string season = "current")
        {
            throw new System.NotImplementedException();
        }

        public Task<ConstructorTable> GetAllCircuitsCollectionAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
