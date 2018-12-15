using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class IsNotStringNullOrEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (string)value;
            return !string.IsNullOrEmpty(data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
