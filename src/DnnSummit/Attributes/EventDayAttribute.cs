using System;

namespace DnnSummit.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EventDayAttribute : Attribute
    {
        public string Day { get; set; }
    }
}
