using DnnSummit.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class SessionTrackToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var track = (SessionTrack?)value;
            
            if (track == null) return SessionTrack.Other.ToString();

            return track.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Unable to convert string to SessionTrack");
        }
    }
}
