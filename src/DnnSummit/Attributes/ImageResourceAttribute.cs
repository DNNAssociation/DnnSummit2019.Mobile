using System;

namespace DnnSummit.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ImageResourceAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
