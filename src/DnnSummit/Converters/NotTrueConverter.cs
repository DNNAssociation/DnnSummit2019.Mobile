using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class NotTrueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (bool)value;
            return !data;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
