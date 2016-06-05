using SQLite.Net.Async;
using SqliteVsRealm.Helpers;
using SqliteVsRealm.Models.Sqlite;
using SqliteVsRealm.Services.Sqlite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteVsRealm.Services.Realm
{
    public class SqliteService : ISqliteService
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private SQLiteAsyncConnection _sqlCon;

        public SqliteService()
        {
            _sqlCon = DependencyService.Get<ISQLite>().GetConnection();

            CreateDatabaseAsync();
        }

        public async void CreateDatabaseAsync()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                await _sqlCon.CreateTableAsync<SqliteTodoItem>().ConfigureAwait(false);
            }
        }

        public async Task<IList<SqliteTodoItem>> GetAll()
        {
            var items = new List<SqliteTodoItem>();
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                items = await _sqlCon.Table<SqliteTodoItem>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task Insert(SqliteTodoItem item)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                await _sqlCon.InsertAsync(item).ConfigureAwait(false);
            }
        }

        public async Task Remove(SqliteTodoItem item)
        {
            await _sqlCon.DeleteAsync(item);
        }
    }
}