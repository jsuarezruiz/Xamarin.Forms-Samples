using TodoLiteDB.iOS.Services.LiteDB;
using Xamarin.Forms;
using TodoLiteDB.Services.LiteDB;
using System.IO;
using System;

[assembly: Dependency(typeof(PathService))]
namespace TodoLiteDB.iOS.Services.LiteDB
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