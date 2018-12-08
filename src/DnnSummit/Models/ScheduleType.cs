using DnnSummit.Attributes;

namespace DnnSummit.Models
{
    public enum ScheduleType
    {
        [ImageResource(Name = "computer")]
        [EventDay(Day = "Day 01")]
        Intro,

        [ImageResource(Name = "group")]
        [EventDay(Day = "Day 02")]
        [EventDay(Day = "Day 03")]
        Conference,

        [ImageResource(Name = "mountain")]
        [EventDay(Day = "Day 04 - Day 05")]
        Slopes
    }
}
