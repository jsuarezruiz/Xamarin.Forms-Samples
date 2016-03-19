namespace AdaptTablet.ErgastAPI.Model.Race
{
    public class Result
    {
        public string Number { get; set; }
        public string Position { get; set; }
        public string PositionText { get; set; }
        public string Points { get; set; }
        public Driver.Driver Driver { get; set; }
        public Constructor.Constructor Constructor { get; set; }
        public string Grid { get; set; }
        public string Laps { get; set; }
        public string Status { get; set; }
        public Time.Time Time { get; set; }
    }
}
