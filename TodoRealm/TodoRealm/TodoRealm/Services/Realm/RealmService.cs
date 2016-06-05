using System.Collections.Generic;
using System.Linq;
using TodoRealm.Models;

namespace TodoRealm.Services.Realm
{
    public class RealmService : IRealmService
    {
        private Realms.Realm _realm;

        public RealmService()
        {
            _realm = Realms.Realm.GetInstance();
        }

        public IList<TodoItem> GetAll()
        {
            var result = _realm.All<TodoItem>().ToList();

            return result;
        }

        public void Insert(TodoItem item)
        {
            var items = _realm.All<TodoItem>().ToList();
            var existTodoItem = items.FirstOrDefault(i => i.Id == item.Id);
            
            if (existTodoItem == null)
            {
                _realm.Write(() =>
                {
                    var todoItem = _realm.CreateObject<TodoItem>();
                    todoItem.Id = items.Count + 1;
                    todoItem.Name = item.Name;
                    todoItem.Notes = item.Notes;
                    todoItem.Done = item.Done;
                });
            }
            else
            {
                using (var trans = _realm.BeginWrite())
                {
                    existTodoItem.Name = item.Name;
                    existTodoItem.Notes = item.Notes;
                    existTodoItem.Done = item.Done;

                    trans.Commit();
                }
            }
        }

        public void Remove(TodoItem item)
        {
            var items = _realm.All<TodoItem>().ToList();
            var existTodoItem = items.FirstOrDefault(i => i.Id == item.Id);

            if (existTodoItem != null)
            {
                using (var trans = _realm.BeginWrite())
                {
                    _realm.Remove(existTodoItem);
                    trans.Commit();
                }
            }
        }
    }
}