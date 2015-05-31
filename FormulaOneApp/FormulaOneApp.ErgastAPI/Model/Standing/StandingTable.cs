using System.Collections.Generic;

namespace FormulaOneApp.ErgastAPI.Model.Standing
{
    public class StandingTable
    {
        public string Season { get; set; }
        public List<StandingList> StandingsLists { get; set; }
    }
}
