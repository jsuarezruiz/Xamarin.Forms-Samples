using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThreeOnePlayground.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EvaluateJavaScriptView : ContentPage
	{
		public EvaluateJavaScriptView ()
		{
			InitializeComponent ();

            EvaluateJsBtn.Clicked += OnEvaluateJsBtnClicked;

        }

        private async void OnEvaluateJsBtnClicked(object sender, System.EventArgs e)
        {
            string result = await EvaluateJsWebView.EvaluateJavaScriptAsync(
                "var test = function(){ return 'This string came from Javascript'; }; test();");
            EvaluateJsLabel.Text = result;
        }
    }
}