using SQLite.Net.Async;

namespace SqliteVsRealm.Services.Sqlite
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
