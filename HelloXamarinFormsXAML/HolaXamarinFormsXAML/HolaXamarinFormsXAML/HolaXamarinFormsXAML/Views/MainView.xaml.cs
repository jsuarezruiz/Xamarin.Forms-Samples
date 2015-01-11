using HolaXamarinFormsXAML.ViewModels;

namespace HolaXamarinFormsXAML.Views
{
	public partial class MainView
	{
        public MainView()
		{
			InitializeComponent ();

            // DataContext de la página, nuestro ViewModel
            BindingContext = new MainViewModel();
		}
	}
}
