using SqliteVsRealm.Models.Realm;
using System.Collections.Generic;

namespace SqliteVsRealm.Services.Realm
{
    public interface IRealmService
    {
        IList<RealmTodoItem> GetAll();

        void Insert(RealmTodoItem item);

        void Remove(RealmTodoItem item);
    }
}
