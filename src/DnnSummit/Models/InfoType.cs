using DnnSummit.Attributes;

namespace DnnSummit.Models
{
    public enum InfoType
    {
        [ImageResource(Name = "business")]
        Sponsors,

        [ImageResource(Name = "business")]
        Venue,

        [ImageResource(Name = "wrench")]
        Credits,

        [ImageResource(Name = "wrench")]
        Feedback,

        [ImageResource(Name = "wrench")]
        Notifications,

        [ImageResource(Name = "download")]
        Update
    }
}
