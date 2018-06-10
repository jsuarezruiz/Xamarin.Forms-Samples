using System.IO;
using TodoLiteDB.Droid.Services.LiteDB;
using TodoLiteDB.Services.LiteDB;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathService))]
namespace TodoLiteDB.Droid.Services.LiteDB
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), AppSettings.DatabaseName);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            return path;
        }
    }
}