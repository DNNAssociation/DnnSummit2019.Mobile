using System;
using Xamarin.Forms;

namespace DnnSummit.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorResourceAttribute : Attribute
    {
        public ColorResourceAttribute()
        {
            Color = Color.Black;
        }

        public ColorResourceAttribute(double r, double g, double b)
        {
            Color = new Color(r, g, b);
        }

        public ColorResourceAttribute(double r, double g, double b, double a)
        {
            Color = new Color(r, g, b, a);
        }

        public Color Color { get; set; }
    }
}
