namespace FormulaOneApp.Classic.Core.Converters
{
    using System;
    using System.Globalization;
    using Cirrious.CrossCore.Converters;

    public class EventToImageConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("../Assets/Events/{0}.jpg", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
