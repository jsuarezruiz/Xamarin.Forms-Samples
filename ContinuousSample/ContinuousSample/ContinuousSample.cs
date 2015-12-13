using System;

using Xamarin.Forms;

namespace ContinuousSample
{
	public class CustomPage : ContentPage
	{
		public CustomPage()
		{
			var label = new Label
			{
				Text = "Continuous Coding Sample. Awesome!",
				TextColor = Color.Red,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.End
			};

			Content = label;
		}
	}

	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms using Continuous!"
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

