using System.Collections.Generic;
using TodoRealm.Models;

namespace TodoRealm.Services.Realm
{
    public interface IRealmService
    {
        IList<TodoItem> GetAll();
        void Insert(TodoItem item);
        void Remove(TodoItem item);
    }
}
