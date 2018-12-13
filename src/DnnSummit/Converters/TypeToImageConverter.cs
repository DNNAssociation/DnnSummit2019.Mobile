using DnnSummit.Attributes;
using DnnSummit.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace DnnSummit.Converters
{
    public abstract class TypeToImageConverter<TEnum> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (TEnum)value;

            if (type == null) type = GetDefaultValue();

            var fieldInfo = type.GetType().GetField(type.ToString());
            var attributes = (ImageResourceAttribute[])fieldInfo?.GetCustomAttributes(typeof(ImageResourceAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Name;
            }

            return string.Empty;
        }

        protected abstract TEnum GetDefaultValue();

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
