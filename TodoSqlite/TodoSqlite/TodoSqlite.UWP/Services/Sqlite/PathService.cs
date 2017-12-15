using System.IO;
using TodoSqlite.Services.Sqlite;
using TodoSqlite.UWP.Services.Sqlite;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace TodoSqlite.UWP.Services.Sqlite
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.DatabaseName);
        }
    }
}