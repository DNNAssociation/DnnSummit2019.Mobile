using System;

namespace DnnSummit.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StringResourceAttribute : Attribute
    {
        public StringResourceAttribute()
        {
        }

        public string Message { get; set; }
    }
}
