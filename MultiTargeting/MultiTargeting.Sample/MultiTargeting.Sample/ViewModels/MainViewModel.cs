using System.Windows.Input;
using Sample.MultiTargeting;
using Xamarin.Forms;

namespace MultiTargeting.Sample.ViewModels
{
	public class MainViewModel : BindableObject
	{
		private string _result;

		public MainViewModel ()
		{
			SampleCommand = new Command (Sample);
		}

		public ICommand SampleCommand { get; }

		public string Result
		{
			get { return _result; }
			set
			{
				_result = value;
				OnPropertyChanged ();
			}
		}

		private void Sample ()
		{
			Result =  CrossMultiTargeting.Current.Sample();
		}
	}
}