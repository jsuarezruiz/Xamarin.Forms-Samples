namespace FormulaOneApp.ErgastAPI.Model.Standing
{
    public class ConstructorStanding
    {
        public string Position { get; set; }
        public string PositionText { get; set; }
        public string Points { get; set; }
        public string Wins { get; set; }
        public Constructor.Constructor Constructor { get; set; }
    }

}
