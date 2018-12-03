using DnnSummit.Attributes;
using DnnSummit.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class ScheduleTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (ScheduleType?)value;

            if (type == null) type = ScheduleType.Conference;

            var fieldInfo = type.GetType().GetField(type.ToString());
            var attributes = (ImageResourceAttribute[])fieldInfo?.GetCustomAttributes(typeof(ImageResourceAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Name;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Unable to convert string to ScheduleType");
        }
    }
}
