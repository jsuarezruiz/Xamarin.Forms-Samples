using System.Diagnostics;

namespace XFHockeyApp.Services.Logger
{
    public class LoggerService : ILoggerService
    {
        public void TrackEvent(string value)
        {
            Debug.WriteLine("Logger: Track Event: " + value);
#if __ANDROID__
            HockeyApp.Metrics.MetricsManager.TrackEvent(value);
#elif __IOS__
            HockeyApp.BITHockeyManager.SharedHockeyManager?.MetricsManager?.TrackEvent(value);
#elif WINDOWS_UWP
            Microsoft.HockeyApp.HockeyClient.Current.TrackEvent(value);
#endif
        }
    }
}