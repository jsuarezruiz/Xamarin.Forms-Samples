using System.Collections.Generic;

namespace AdaptTablet.ErgastAPI.Model.Standing
{
    public class DriverStanding
    {
        public string Position { get; set; }
        public string PositionText { get; set; }
        public string Points { get; set; }
        public string Wins { get; set; }
        public Driver.Driver Driver { get; set; }
        public List<Constructor.Constructor> Constructors { get; set; }
    }
}
