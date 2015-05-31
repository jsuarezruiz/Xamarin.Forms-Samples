namespace FormulaOneApp.ErgastAPI.Model.Standing
{
    public class StandingMRData
    {
        public string Xmlns { get; set; }
        public string Series { get; set; }
        public string Url { get; set; }
        public string Limit { get; set; }
        public string Offset { get; set; }
        public string Total { get; set; }
        public StandingTable StandingsTable { get; set; }
    }
}
