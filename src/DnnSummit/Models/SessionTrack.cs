using DnnSummit.Attributes;

namespace DnnSummit.Models
{
    public enum SessionTrack
    {
        [ColorResource(255, 0, 0)]
        Development,

        [ColorResource(0, 255, 0)]
        Marketing,

        [ColorResource(0, 0, 255)]
        Design

    }
}
