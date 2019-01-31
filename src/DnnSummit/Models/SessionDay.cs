using DnnSummit.Attributes;

namespace DnnSummit.Models
{
    public enum SessionDay
    {

        None = 0,

        [StringResource(Message = "Day 1")]
        Day1 = 1,

        [StringResource(Message = "Day 2")]
        Day2 = 2
    }
}
