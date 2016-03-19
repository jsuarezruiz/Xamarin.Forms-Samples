using AdaptTablet.ErgastAPI.Model.Circuit;
using AdaptTablet.ErgastAPI.Model.Constructor;
using AdaptTablet.ErgastAPI.Model.Driver;

namespace AdaptTablet.ErgastAPI.Model
{
    using Race;

    public class MRData
    {
        public string Xmlns { get; set; }
        public string Series { get; set; }
        public string Url { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
        public string Total { get; set; }
        public RaceTable RaceTable { get; set; }
        public DriverTable DriverTable { get; set; }
        public ConstructorTable ConstructorTable { get; set; } 
        public CircuitTable CircuitTable { get; set; }
    }
}
