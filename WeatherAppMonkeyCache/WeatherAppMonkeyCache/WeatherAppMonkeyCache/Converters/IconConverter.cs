using System;
using System.Globalization;
using Xamarin.Forms;

namespace WeatherAppMonkeyCache.Converters
{
    public class IconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var iconType = value.ToString();

            switch(iconType)
            {
                case "01n":
                    if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/moon.png";
                    else
                        return "moon.png";
                case "01d":
                    if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/sun.png";
                    else
                        return "sun.png";
                case "02n":
                case "02d":
                case "04d":
                    if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/cloud.png";
                    else
                        return "cloud.png";
                case "10d":
                    if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/rain.png";
                    else
                        return "rain.png";
                default:
                    if (Device.RuntimePlatform == Device.UWP)
                        return "Assets/cloud.png";
                    else
                        return "cloud.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}