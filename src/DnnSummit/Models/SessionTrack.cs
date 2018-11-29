using DnnSummit.Attributes;

namespace DnnSummit.Models
{
    public enum SessionTrack
    {
        [ColorResource(229, 125, 60)]
        [TrackName(Name = "Development")]
        Development,

        [ColorResource(30, 52, 93)]
        [TrackName(Name = "DNN")]
        DNN,

        [ColorResource(114, 113, 38)]
        [TrackName(Name = "Integration")]
        Integration,
        
        [ColorResource(111, 37, 95)]
        [TrackName(Name = "Marketing")]
        Marketing,

        [ColorResource(47, 100, 112)]
        [TrackName(Name = "Security")]
        Security,

        [ColorResource(47, 100, 112)]
        [TrackName(Name = "UX Dev")]
        UXDev,

        [ColorResource(47, 100, 112)]
        [TrackName(Name = "Other")]
        Other
    }
}