using SQLite.Net.Async;

namespace TodoSqlite.Services.Sqlite
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
