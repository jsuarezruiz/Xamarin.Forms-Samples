using System;
using System.IO;
using TodoSqlite.iOS.Services.Sqlite;
using TodoSqlite.Services.Sqlite;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace TodoSqlite.iOS.Services.Sqlite
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, AppSettings.DatabaseName);
        }
    }
}