using System.Collections.Generic;

namespace FormulaOneApp.ErgastAPI.Model.Race
{
    public class RaceTable
    {
        public string Season { get; set; }
        public List<Race> Races { get; set; }
    }
}
