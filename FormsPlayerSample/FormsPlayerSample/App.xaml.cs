namespace FormsPlayerSample
{
	using System.Diagnostics;
	using Xamarin.Forms;

	public partial class App : Application
	{
		public App()
		{
			//InitializeComponent();

			MainPage = new NavigationPage(new MainView());
		}

		protected override void OnStart()
		{
			Debug.WriteLine("OnStart");
		}

		protected override void OnSleep()
		{
			Debug.WriteLine("OnSleep");
		}

		protected override void OnResume()
		{
			Debug.WriteLine("OnResume");
		}
	}
}