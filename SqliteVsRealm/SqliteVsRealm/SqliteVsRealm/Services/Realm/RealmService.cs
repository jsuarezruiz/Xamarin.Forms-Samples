using SqliteVsRealm.Models.Realm;
using System.Collections.Generic;
using System.Linq;

namespace SqliteVsRealm.Services.Realm
{
    public class RealmService : IRealmService
    {
        private Realms.Realm _realm;

        public RealmService()
        {
            _realm = Realms.Realm.GetInstance();
        }

        public IList<RealmTodoItem> GetAll()
        {
            var result = _realm.All<RealmTodoItem>().ToList();

            return result;
        }

        public void Insert(RealmTodoItem item)
        {
            _realm.Write(() =>
            {
                var todoItem = _realm.CreateObject<RealmTodoItem>();
                todoItem.Id = item.Id;
                todoItem.Name = item.Name;
                todoItem.Notes = item.Notes;
                todoItem.Done = item.Done;
            });
        }

        public void Remove(RealmTodoItem item)
        {
            using (var trans = _realm.BeginWrite())
            {
                _realm.Remove(item);
                trans.Commit();
            }
        }
    }
}