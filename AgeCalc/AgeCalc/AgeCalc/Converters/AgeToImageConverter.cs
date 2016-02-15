using System;
using System.Globalization;
using Xamarin.Forms;

namespace AgeCalc.Converters
{
    public class AgeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var age = System.Convert.ToInt32(value);

            if (age >= 0 && age <= 1)
                return "1.jpg";
            if (age > 1 && age <= 5)
                return "2.jpg";
            if (age > 5 && age <= 16)
                return "3.jpg";
            if (age > 16 && age <= 29)
                return "4.jpg";
            if (age > 29 && age <= 45)
                return "5.jpg";
            if (age > 45 && age <= 60)
                return "6.jpg";
            if (age > 60 && age <= 110)
                return "7.jpg";
            if (age > 110)
                return "8.jpg";

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
