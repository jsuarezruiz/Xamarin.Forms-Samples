using SqliteVsRealm.Models.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqliteVsRealm.Services.Realm
{
    public interface ISqliteService
    {
        Task<IList<SqliteTodoItem>> GetAll();
        Task Insert(SqliteTodoItem item);
        Task Remove(SqliteTodoItem item);
    }
}