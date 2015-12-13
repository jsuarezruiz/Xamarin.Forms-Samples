using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlC
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();
		}
	}
}

