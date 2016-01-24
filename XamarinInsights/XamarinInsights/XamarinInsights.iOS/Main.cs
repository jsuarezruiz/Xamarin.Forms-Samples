using UIKit;
using XamarinInsights.Common;

namespace XamarinInsights.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // Initialize Insights
            Xamarin.Insights.Initialize(Consts.INSIGHTS_API_KEY);

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
