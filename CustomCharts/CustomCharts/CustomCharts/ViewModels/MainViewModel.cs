using SkiaSharp;
using Xamarin.Forms;

namespace CustomCharts.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private Microcharts.Entry[] entries = new[]
        {
            new Microcharts.Entry(212)
            {
                Label = "UWP",
                ValueLabel = "212",
                Color = SKColor.Parse("#2c3e50")
            },
            new Microcharts.Entry(248)
            {
                Label = "Android",
                ValueLabel = "248",
                Color = SKColor.Parse("#77d065")
            },
            new Microcharts.Entry(128)
            {
                Label = "iOS",
                ValueLabel = "128",
                Color = SKColor.Parse("#b455b6")
            },
            new Microcharts.Entry(514)
            {
                Label = "Shared",
                ValueLabel = "514",
                Color = SKColor.Parse("#3498db")
            }
        };

        public Microcharts.Entry[] Entries { get { return  entries; } }
    }
}