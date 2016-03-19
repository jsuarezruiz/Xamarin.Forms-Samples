using System.Collections.Generic;

namespace AdaptTablet.ErgastAPI.Model.Race
{
    public class Race
    {
        public string Season { get; set; }
        public string Round { get; set; }
        public string Url { get; set; }
        public string RaceName { get; set; }
        public Circuit.Circuit Circuit { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public List<QualifyingResult> QualifyingResults { get; set; }
        public List<Result> Results { get; set; }
    }

}
