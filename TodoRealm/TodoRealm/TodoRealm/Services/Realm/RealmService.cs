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
                    var todoItem = new TodoItem
                    {
                        Id = items.Count + 1,
                        Name = item.Name,
                        Notes = item.Notes,
                        Done = item.Done
                    };

                    _realm.Add(todoItem);
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