using System.Collections.Generic;

namespace FormulaOneApp.ErgastAPI.Model.Standing
{
    public class StandingList
    {
        public string Season { get; set; }
        public string Round { get; set; }
        public List<DriverStanding> DriverStandings { get; set; }  
        public List<ConstructorStanding> ConstructorStandings { get; set; }
    }
}
