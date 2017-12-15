using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoSqlite.Helpers;
using TodoSqlite.Models;
using TodoSqlite.Services.Sqlite;
using Xamarin.Forms;

namespace TodoSqlite.Services.Sqlite
{
    public class SqliteService : ISqliteService
    {
        private static readonly AsyncLock Mutex = new AsyncLock();
        private SQLiteAsyncConnection _sqlCon;

        public SqliteService()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            _sqlCon = new SQLiteAsyncConnection(databasePath);

            CreateDatabaseAsync();
        }

        public async void CreateDatabaseAsync()
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                await _sqlCon.CreateTableAsync<TodoItem>().ConfigureAwait(false);
            }
        }

        public async Task<IList<TodoItem>> GetAll()
        {
            var items = new List<TodoItem>();
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                items = await _sqlCon.Table<TodoItem>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task Insert(TodoItem item)
        {
            using (await Mutex.LockAsync().ConfigureAwait(false))
            {
                var existingTodoItem = await _sqlCon.Table<TodoItem>()
                        .Where(x => x.Id == item.Id)
                        .FirstOrDefaultAsync();

                if (existingTodoItem == null)
                {
                    await _sqlCon.InsertAsync(item).ConfigureAwait(false);
                }
                else
                {
                    item.Id = existingTodoItem.Id;
                    await _sqlCon.UpdateAsync(item).ConfigureAwait(false);
                }
            }
        }

        public async Task Remove(TodoItem item)
        {
            await _sqlCon.DeleteAsync(item);
        }
    }
}