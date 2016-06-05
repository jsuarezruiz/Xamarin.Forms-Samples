using SQLite.Net.Attributes;

namespace SqliteVsRealm.Models.Sqlite
{
    public class SqliteTodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
