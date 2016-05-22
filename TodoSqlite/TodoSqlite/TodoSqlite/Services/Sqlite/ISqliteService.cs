using System.Collections.Generic;
using System.Threading.Tasks;
using TodoSqlite.Models;

namespace TodoSqlite.Services.Realm
{
    public interface ISqliteService
    {
        Task<IList<TodoItem>> GetAll();
        Task Insert(TodoItem item);
        Task Remove(TodoItem item);
    }
}