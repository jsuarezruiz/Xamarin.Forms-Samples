namespace FormulaOneApp.Classic.Core.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Cirrious.MvvmCross.ViewModels;
    using ErgastAPI.Model.Race;
    using ErgastAPI.Services.Race;
    using Rss;
    using Rss.Models;

    public class MainViewModel : MvxViewModel
    {
        //Consts
        private const string Formula1Url = "http://www.theguardian.com/sport/formulaone/rss";

        //Services
        private readonly IRaceService _raceService;

        //Variables 
        private Race _nextRace;
        private ObservableCollection<RssItem> _news;
        private TimeSpan _countdown;

        // Commands
        private MvxCommand _standingsCommand;
        private MvxCommand _driversCommand;
        private MvxCommand _circuitsCommand;

        public MainViewModel(IRaceService raceService)
        {
            _raceService = raceService;

            LoadNextRacingEvent();
            LoadNews();
        }

        public Race NextRace
        {
            get { return _nextRace; }
            set
            {
                _nextRace = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan Countdown
        {
            get { return _countdown; }
            set
            {
                _countdown = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RssItem> News
        {
            get { return _news; }
            set
            {
                _news = value;
                RaisePropertyChanged();
            }
        }

        public ICommand StandingsCommand
        {
            get { return _standingsCommand = _standingsCommand ?? new MvxCommand(StandingsCommandExecute); }
        }

        public ICommand DriversCommand
        {
            get { return _driversCommand = _driversCommand ?? new MvxCommand(DriversCommandExecute); }
        }

        public ICommand CircuitsCommand
        {
            get { return _circuitsCommand = _circuitsCommand ?? new MvxCommand(CircuitsCommandExecute); }
        }

        private async Task LoadNextRacingEvent()
        {
            var today = DateTime.Today;
            var seasonSchedule = await _raceService.GetSeasonScheduleCollectionAsync();
            foreach (var race in seasonSchedule.Races)
            {
                if (Convert.ToDateTime(race.Date) > today)
                {
                    NextRace = race;
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>  
        public void LoadNews()
        {
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(Formula1Url);
                request.BeginGetResponse(token =>
                {
                    using (var response = request.EndGetResponse(token) as HttpWebResponse)
                        if (response != null)
                        {
                            using (Stream stream = response.GetResponseStream())
                            {
                                using (var sReader = new StreamReader(stream))
                                {
                                    string feedContent = sReader.ReadToEnd();
                                    var rssResult = FeedReader.LoadFeed(feedContent);

                                    News = new ObservableCollection<RssItem>();
                                    foreach (var item in rssResult.Items)
                                    {
                                        News.Add(item);
                                    }
                                }
                            }
                        }
                }, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void StandingsCommandExecute()
        {
            ShowViewModel<StandingsViewModel>();
        }

        private void DriversCommandExecute()
        {
            ShowViewModel<DriverListViewModel>();
        }

        private void CircuitsCommandExecute()
        {
            ShowViewModel<CircuitListViewModel>();
        }
    }
}