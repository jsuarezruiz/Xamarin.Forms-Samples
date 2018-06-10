using LiteDB;
using System.Collections.Generic;
using TodoLiteDB.Models;
using Xamarin.Forms;

namespace TodoLiteDB.Services.LiteDB
{
    public class LiteDBService : ILiteDBService
    {
        protected LiteCollection<TodoItem> _collection;

        public LiteDBService()
        {
            var db = new LiteDatabase(DependencyService.Get<IPathService>().GetDatabasePath());
            _collection = db.GetCollection<TodoItem>();

            var mapper = BsonMapper.Global;

            mapper.Entity<TodoItem>()
                .Id(x => x.Id);
        }
        public IEnumerable<TodoItem> ReadAllItems()
        {
            var all = _collection.FindAll();
            return new List<TodoItem>(all);
        }

        public TodoItem CreateItem(TodoItem item)
        {
            var existingTodoItem = _collection.FindById(item.Id);

            if (existingTodoItem == null)
                _collection.Insert(item);
            else
                _collection.Update(item);

            return item;
        }

        public TodoItem UpdateItem(TodoItem item)
        {
            _collection.Update(item);
            return item;
        }

        public TodoItem DeleteItem(TodoItem item)
        {
            _collection.Delete(i => i.Id.Equals(item.Id));
            return item;
        }
    }
}