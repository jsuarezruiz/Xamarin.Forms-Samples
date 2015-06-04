using FormulaOneApp.Services.Internet;

namespace FormulaOneApp.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using ErgastAPI.Services.Race;
    using Rss;
    using Rss.Models;
    using ErgastAPI.Model.Race;
    using Services.Navigation;
    using Base;

    public class MainViewModel : ViewModelBase
    {
        //Consts
        private const string Formula1Url = "http://www.theguardian.com/sport/formulaone/rss";

        //Services
        private readonly INavigationService _navigationService;
        private readonly IRaceService _raceService;
        private readonly IInternetService _internetService;

        //Variables 
        private Race _nextRace;
        private ObservableCollection<RssItem> _news;
        private TimeSpan _countdown;

        // Commands
        private ICommand _standingsCommand;
        private ICommand _driversCommand;
        private ICommand _circuitsCommand;

        public MainViewModel(INavigationService navigationService, IRaceService raceService, IInternetService internetService)
        {
            _navigationService = navigationService;
            _raceService = raceService;
            _internetService = internetService;
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
            get { return _standingsCommand = _standingsCommand ?? new DelegateCommand(StandingsCommandExecute); }
        }

        public ICommand DriversCommand
        {
            get { return _driversCommand = _driversCommand ?? new DelegateCommand(DriversCommandExecute); }
        }

        public ICommand CircuitsCommand
        {
            get { return _circuitsCommand = _circuitsCommand ?? new DelegateCommand(CircuitsCommandExecute); }
        }

        public override async void OnAppearing(object navigationContext)
        {
            await LoadNextRacingEvent();
            LoadNews();

            base.OnAppearing(navigationContext);
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
            _navigationService.NavigateTo<StandingsViewModel>();
        }

        private void DriversCommandExecute()
        {
            _navigationService.NavigateTo<DriverListViewModel>();
        }

        private void CircuitsCommandExecute()
        {
            _navigationService.NavigateTo<CircuitListViewModel>();
        }
    }
}