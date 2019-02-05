using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (string)value;
            if (string.IsNullOrEmpty(item))
            {
                return false;
            }

            if (bool.TryParse(item, out bool result))
            {
                return result;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (bool?)value;
            if (item.HasValue)
            {
                return item.ToString();
            }

            return string.Empty;
        }
    }
}
