using System.Collections.Generic;
using System.Threading.Tasks;
using TodoSqlite.Models;

namespace TodoSqlite.Services.Sqlite
{
    public interface ISqliteService
    {
        Task<IList<TodoItem>> GetAll();
        Task Insert(TodoItem item);
        Task Remove(TodoItem item);
    }
}