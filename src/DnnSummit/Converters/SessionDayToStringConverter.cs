using DnnSummit.Attributes;
using DnnSummit.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class SessionDayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var day = (SessionDay?)value;
            var defaultMessage = "None";

            if (day == null) return defaultMessage;

            var fieldInfo = day.GetType().GetField(day.ToString());
            var attributes = (StringResourceAttribute[])fieldInfo?.GetCustomAttributes(typeof(StringResourceAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Message;
            }

            return defaultMessage;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Unable to convert string to SessionDay");
        }
    }
}
