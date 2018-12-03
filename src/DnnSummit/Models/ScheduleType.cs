using DnnSummit.Attributes;

namespace DnnSummit.Models
{
    public enum ScheduleType
    {
        [ImageResource(Name = "computer")]
        Intro,

        [ImageResource(Name = "group")]
        Conference,

        [ImageResource(Name = "mountain")]
        Slopes
    }
}
