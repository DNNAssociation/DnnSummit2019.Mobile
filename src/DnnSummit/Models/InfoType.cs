using DnnSummit.Attributes;

namespace DnnSummit.Models
{
    public enum InfoType
    {
        [ImageResource(Name = "business")]
        Sponsors,

        [ImageResource(Name = "wrench")]
        About
    }
}
