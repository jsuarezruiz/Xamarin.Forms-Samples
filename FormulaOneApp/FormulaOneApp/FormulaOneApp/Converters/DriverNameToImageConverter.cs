namespace FormulaOneApp.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class DriverNameToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return ImageSource.FromResource(string.Format("FormulaOneApp.Images.Drivers.{0}.jpg", value));
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
