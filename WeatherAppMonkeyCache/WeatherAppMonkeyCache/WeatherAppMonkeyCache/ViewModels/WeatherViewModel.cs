using MonkeyCache.FileStore;
using Plugin.Connectivity;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherAppMonkeyCache.Models;
using WeatherAppMonkeyCache.Services;
using Xamarin.Forms;

namespace WeatherAppMonkeyCache.ViewModels
{
    public class WeatherViewModel : BindableObject
    {
        private bool _isBusy;
        private string _temp;
        private string _condition;
        private WeatherForecastRoot _forecast;
        private ICommand _reloadCommand;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public string Temp
        {
            get { return _temp; }
            set
            {
                _temp = value;
                OnPropertyChanged();
            }
        }

        public string Condition
        {
            get { return _condition; }
            set
            {
                _condition = value;
                OnPropertyChanged();
            }
        }

        public WeatherForecastRoot Forecast
        {
            get { return _forecast; }
            set
            {
                _forecast = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReloadCommand =>
            _reloadCommand ??
            (_reloadCommand = new Command(async () => await GetWeatherAsync()));

        public async Task GetWeatherAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;


            try
            {
                var location = AppSettings.Location.Trim();

                WeatherRoot weatherRoot = null;

                if (!CrossConnectivity.Current.IsConnected)
                {
                    weatherRoot = Barrel.Current.Get<WeatherRoot>(key: location);
                    Forecast = Barrel.Current.Get<WeatherForecastRoot>(key: weatherRoot.CityId.ToString());

                }
                else if (!Barrel.Current.IsExpired(key: location))
                {
                    weatherRoot = Barrel.Current.Get<WeatherRoot>(key: location);
                    Forecast = Barrel.Current.Get<WeatherForecastRoot>(key: weatherRoot.CityId.ToString());

                }
                else
                {
                    weatherRoot = await WeatherService.Instance.GetWeatherAsync(location);
                    Barrel.Current.Add(key: location, data: weatherRoot, expireIn: TimeSpan.FromHours(1));
                    Forecast = await WeatherService.Instance.GetForecast(weatherRoot.CityId);
                    Barrel.Current.Add(key: weatherRoot.CityId.ToString(), data: Forecast, expireIn: TimeSpan.FromHours(1));
                }

  
                var unit = "C";
                Temp = $"{weatherRoot?.MainWeather?.Temperature ?? 0}°{unit}";
                Condition = $"{weatherRoot.Name}: {weatherRoot?.Weather?[0]?.Description ?? string.Empty}";
            }
            catch (Exception ex)
            {
                Temp = "Unable to get Weather";
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}