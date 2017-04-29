using System.Diagnostics;
using Xamarin.Forms;

namespace TestFastRenderers.Views
{
    public partial class BasicTestView : ContentPage
    {
        public BasicTestView()
        {
            var watch = Stopwatch.StartNew();
            InitializeComponent();
            watch.Stop();
            Debug.WriteLine("============================================");
            Debug.WriteLine("Elapsed: " + watch.ElapsedMilliseconds + "ms");
        }
    }
}