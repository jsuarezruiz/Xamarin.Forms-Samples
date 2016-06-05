using Realms;

namespace TodoRealm.Models
{
    public class TodoItem : RealmObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
