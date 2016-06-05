using Realms;

namespace SqliteVsRealm.Models.Realm
{
    public class RealmTodoItem : RealmObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
