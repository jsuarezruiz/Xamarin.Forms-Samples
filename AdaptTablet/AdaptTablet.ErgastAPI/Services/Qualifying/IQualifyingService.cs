namespace AdaptTablet.ErgastAPI.Services.Qualifying
{
    using System.Threading.Tasks;
    using Model.Race;

    public interface IQualifyingService
    {
        Task<RaceTable> GetQualifyingResultAsync(string season = "current", int round = 1);
    }
}
