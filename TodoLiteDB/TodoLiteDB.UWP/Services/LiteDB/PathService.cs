using TodoLiteDB.UWP.Services.LiteDB;
using Xamarin.Forms;
using TodoLiteDB.Services.LiteDB;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(PathService))]
namespace TodoLiteDB.UWP.Services.LiteDB
{
    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.DatabaseName);
        }
    }
}