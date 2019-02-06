using DnnSummit.Attributes;

namespace DnnSummit.Models
{
    public enum InfoType
    {
        [ImageResource(Name = "power")]
        Sponsors,

        [ImageResource(Name = "business")]
        Venue,

        [ImageResource(Name = "flag")]
        Credits,

        [ImageResource(Name = "assignment")]
        Feedback,

        [ImageResource(Name = "wrench")]
        Notifications,

        [ImageResource(Name = "download")]
        Update
    }
}
