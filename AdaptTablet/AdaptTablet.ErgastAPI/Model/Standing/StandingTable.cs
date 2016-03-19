using System.Collections.Generic;

namespace AdaptTablet.ErgastAPI.Model.Standing
{
    public class StandingTable
    {
        public string Season { get; set; }
        public List<StandingList> StandingsLists { get; set; }
    }
}
