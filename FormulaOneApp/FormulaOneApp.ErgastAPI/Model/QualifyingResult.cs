namespace FormulaOneApp.ErgastAPI.Model
{
    public class QualifyingResult
    {
        public string Number { get; set; }
        public string Position { get; set; }
        public Driver.Driver Driver { get; set; }
        public Constructor.Constructor Constructor { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
    }

}
