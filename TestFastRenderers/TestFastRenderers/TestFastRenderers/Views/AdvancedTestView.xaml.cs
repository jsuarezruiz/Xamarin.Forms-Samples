using System.Diagnostics;
using TestFastRenderers.ViewModels;
using Xamarin.Forms;

namespace TestFastRenderers.Views
{
    public partial class AdvancedTestView : ContentPage
    {
        public AdvancedTestView()
        {
            var watch = Stopwatch.StartNew();
            InitializeComponent();
            watch.Stop();
            Debug.WriteLine("============================================");
            Debug.WriteLine("Elapsed: " + watch.ElapsedMilliseconds + "ms");

            BindingContext = new AdvancedTestViewModel();
        }
    }
}