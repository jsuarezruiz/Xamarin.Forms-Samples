namespace AdaptTablet.Converters
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
				if (Device.OS == TargetPlatform.iOS)
                	return string.Format("Drivers/{0}.jpg", value);
				else if (Device.OS == TargetPlatform.Android)
                	return string.Format("Drivers/{0}.jpg", value);
				else
                	return string.Format("ms-appx:///Assets/Drivers/{0}.jpg", value);
            }
            catch
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
