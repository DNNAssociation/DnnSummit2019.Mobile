using System;

namespace DnnSummit.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class TrackNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
