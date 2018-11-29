using System;
using Xamarin.Forms;

namespace DnnSummit.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorResourceAttribute : Attribute
    {
        private const int ColorFactor = 255;
        public ColorResourceAttribute()
        {
            Color = Color.Black;
        }

        public ColorResourceAttribute(double r, double g, double b)
        {
            r = r / ColorFactor;
            g = g / ColorFactor;
            b = b / ColorFactor;
            Color = new Color(r, g, b);
        }

        public ColorResourceAttribute(double r, double g, double b, double a)
        {
            r = r / ColorFactor;
            g = g / ColorFactor;
            b = b / ColorFactor;
            a = a / ColorFactor;
            Color = new Color(r, g, b, a);
        }

        public Color Color { get; set; }
    }
}
