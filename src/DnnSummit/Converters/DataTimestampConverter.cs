using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class DataTimestampConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timestamp = (DateTime)value;

            return string.Format(Constants.Messages.LastRetrieved, timestamp.ToString("MM/dd/yy @ h:mm tt")); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
