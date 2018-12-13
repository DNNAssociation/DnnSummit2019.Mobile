using DnnSummit.Models;

namespace DnnSummit.Converters
{
    public class ScheduleTypeToImageConverter : TypeToImageConverter<ScheduleType>
    {
        protected override ScheduleType GetDefaultValue()
        {
            return ScheduleType.Conference;
        }
    }
}
