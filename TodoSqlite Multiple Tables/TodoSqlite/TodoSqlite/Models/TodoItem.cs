using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace TodoSqlite.Models
{
    [Table("TodoItems")]
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        public List<Step> Steps { get; set; }
    }
}