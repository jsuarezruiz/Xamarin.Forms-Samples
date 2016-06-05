using SqliteVsRealm.Models.Realm;
using SqliteVsRealm.Models.Sqlite;
using SqliteVsRealm.Services.Realm;
using SqliteVsRealm.ViewModels.Base;
using System.Windows.Input;

namespace SqliteVsRealm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _log;

        private ICommand _insertCommand;
        private ICommand _queryCommand;
        private ICommand _deleteCommand;

        private readonly ISqliteService _sqliteService;
        private readonly IRealmService _realmService;

        public MainViewModel(
            ISqliteService sqliteService,
            IRealmService realmService)
        {
            _sqliteService = sqliteService;
            _realmService = realmService;
        }

        public string Log
        {
            get { return _log; }
            set
            {
                _log = value;
                RaisePropertyChanged();
            }
        }

        public ICommand InsertCommand
        {
            get { return _insertCommand = _insertCommand ?? new DelegateCommand(InsertCommandExecute); }
        }

        public ICommand QueryCommand
        {
            get { return _queryCommand = _queryCommand ?? new DelegateCommand(QueryCommandExecute); }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand = _deleteCommand ?? new DelegateCommand(DeleteCommandExecute); }
        }

        private async void InsertCommandExecute()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                await _sqliteService.Insert(new SqliteTodoItem
                {
                    Id = i + 1,
                    Name = string.Format("Name {0}", i + 1),
                    Notes = string.Format("Notes {0}", i + 1),
                    Done = false
                });
            }
            watch.Stop();

            Log += $"SQLite: INSERT 1000 items in {watch.ElapsedMilliseconds} milliseconds\n";

            watch.Restart();
            for (int i = 0; i < 1000; i++)
            {
                _realmService.Insert(new RealmTodoItem
                {
                    Id = i + 1,
                    Name = string.Format("Name {0}", i + 1),
                    Notes = string.Format("Notes {0}", i + 1),
                    Done = false
                });
            }
            watch.Stop();

            Log += $"Realm: INSERT 1000 items in {watch.ElapsedMilliseconds} milliseconds\n";
        }

        private async void QueryCommandExecute()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var sqliteResult = await _sqliteService.GetAll();
            watch.Stop();

            Log += $"SQLite: QUERY 1000 items in {watch.ElapsedMilliseconds} milliseconds\n";

            watch.Restart();
            var realmResult = _realmService.GetAll();
            watch.Stop();

            Log += $"Realm: QUERY 1000 items in {watch.ElapsedMilliseconds} milliseconds\n";
        }

        private async void DeleteCommandExecute()
        {
            var sqliteResult = await _sqliteService.GetAll();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (var item in sqliteResult)
            {
                await _sqliteService.Remove(item);
            }
            watch.Stop();

            Log += $"SQLite: DELETE 1000 items in {watch.ElapsedMilliseconds} milliseconds\n";

            var realmResult = _realmService.GetAll();
            watch.Restart();
            foreach (var item in realmResult)
            {
                _realmService.Remove(item);
            }
            watch.Stop();

            Log += $"Realm: DELETE 1000 items in {watch.ElapsedMilliseconds} milliseconds\n";
        }
    }
}
