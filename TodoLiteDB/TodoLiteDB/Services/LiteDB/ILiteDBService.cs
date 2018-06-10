using System.Collections.Generic;
using TodoLiteDB.Models;

namespace TodoLiteDB.Services.LiteDB
{
    public interface ILiteDBService
    {
        IEnumerable<TodoItem> ReadAllItems();
        TodoItem CreateItem(TodoItem item);
        TodoItem UpdateItem(TodoItem item);
        TodoItem DeleteItem(TodoItem item);
    }
}