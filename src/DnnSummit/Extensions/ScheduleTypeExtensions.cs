using DnnSummit.Attributes;
using DnnSummit.Models;
using System;
using System.Linq;

namespace DnnSummit.Extensions
{
    public static class ScheduleTypeExtensions
    {
        public static ScheduleType ToScheduleType(this string input)
        {
            var type = typeof(ScheduleType);
            var members = type.GetMembers();
            foreach (var memberInfo in members)
            {
                var attributes = memberInfo.GetCustomAttributes(typeof(EventDayAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    var eventDayAttributes = (EventDayAttribute[])attributes;
                    foreach (var eventDay in eventDayAttributes)
                    {
                        if (eventDay != null && eventDay.Day == input)
                        {
                            var values = (ScheduleType[])Enum.GetValues(type);
                            return values.FirstOrDefault(x => x.ToString() == memberInfo.Name);
                        }
                    }
                }
            }

            return ScheduleType.Slopes;
        }
    }
}
