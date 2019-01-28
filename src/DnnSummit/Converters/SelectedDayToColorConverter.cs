using DnnSummit.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public class SelectedDayToColorConverter : IValueConverter
    {
        public SessionDay Day { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedDay = (SessionDay?)value;
            var defaultColor = (Color)Application.Current.Resources["Orange"];
            var selectedColor = (Color)Application.Current.Resources["DarkBlue"];

            if (selectedDay == null)
                return defaultColor;

            return selectedDay == Day ?
                selectedColor :
                defaultColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
