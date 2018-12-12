using DnnSummit.Models;

namespace DnnSummit.Converters
{
    public class InfoTypeToImageConverter : TypeToImageConverter<InfoType>
    {
        protected override InfoType GetDefaultValue()
        {
            return InfoType.Sponsors;
        }
    }
}
