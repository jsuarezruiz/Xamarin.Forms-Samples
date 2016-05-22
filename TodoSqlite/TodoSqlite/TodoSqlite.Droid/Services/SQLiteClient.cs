using TodoSqlite.Services.Sqlite;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using TodoSqlite.Droid.Services;

[assembly: Dependency(typeof(SQLiteClient))]
namespace TodoSqlite.Droid.Services
{
    public class SQLiteClient : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "Todo.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLitePlatformAndroid();

            var connectionWithLock = new SQLiteConnectionWithLock(
                                         platform,
                                         new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}