using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class PercentToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var percent = ((double)value) * 100;
            return $"{percent} %";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
