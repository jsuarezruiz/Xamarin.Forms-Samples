using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormulaOneApp.Converters
{
    public class ScuderiaNameToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromResource(string.Format("FormulaOneApp.Images.Cars.{0}.png", value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
