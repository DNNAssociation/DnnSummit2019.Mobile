using DnnSummit.Attributes;
using DnnSummit.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class SessionTrackToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var track = (SessionTrack?)value;
            var defaultColor = Color.Black;

            if (track == null) return defaultColor;

            var fieldInfo = track.GetType().GetField(track.ToString());
            var attributes = (ColorResourceAttribute[])fieldInfo?.GetCustomAttributes(typeof(ColorResourceAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Color;
            }

            return defaultColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Unable to convert color to SessionTrack");
        }
    }
}
