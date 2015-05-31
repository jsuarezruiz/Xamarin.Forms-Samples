namespace FormulaOneApp.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class EventToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromResource(string.Format("FormulaOneApp.Images.Events.{0}.jpg", value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
