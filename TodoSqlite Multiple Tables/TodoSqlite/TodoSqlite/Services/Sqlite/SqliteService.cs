using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoSqlite.Helpers;
using TodoSqlite.Models;
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
            await _sqlCon.CreateTableAsync<Step>(CreateFlags.None).ConfigureAwait(false);
            await _sqlCon.CreateTableAsync<TodoItem>(CreateFlags.None).ConfigureAwait(false);
        }

        public async Task<IList<TodoItem>> GetAll()
        {
            return await _sqlCon.GetAllWithChildrenAsync<TodoItem>();
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
                    await _sqlCon.InsertWithChildrenAsync(item, recursive: true).ConfigureAwait(false);
                }
                else
                {
                    item.Id = existingTodoItem.Id;
                    await _sqlCon.UpdateWithChildrenAsync(item).ConfigureAwait(false);
                }
            }
        }

        public async Task Remove(TodoItem item)
        {
            await _sqlCon.DeleteAsync(item);
        }
    }
}