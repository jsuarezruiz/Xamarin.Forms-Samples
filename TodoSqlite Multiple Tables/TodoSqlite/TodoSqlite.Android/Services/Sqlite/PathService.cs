using System;
using System.IO;
using TodoSqlite.Droid.Services.Sqlite;
using TodoSqlite.Services.Sqlite;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace TodoSqlite.Droid.Services.Sqlite
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, AppSettings.DatabaseName);
        }
    }
}