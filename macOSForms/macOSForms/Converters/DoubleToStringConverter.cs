using System;
using System.Globalization;
using Xamarin.Forms;

namespace macOSForms.Converters
{
	public class DoubleToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType,
							  object parameter, CultureInfo culture)
		{
			double number = (double)value;

			if (number == 0)
			{
                return string.Empty;
			}

			return number.ToString();
		}

		public object ConvertBack(object value, Type targetType,
								  object parameter, CultureInfo culture)
		{
			double number = 0;
			Double.TryParse((string)value, out number);
			return number;
		}
	}
}