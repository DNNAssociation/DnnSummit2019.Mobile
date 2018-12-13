using DnnSummit.Data.Models;

namespace DnnSummit.Data.Extensions
{
    public static class SponsorLevelExtensions
    {
        public static SponsorLevel ToSponsorLevel(this string input)
        {
            if (!int.TryParse(input, out int value))
            {
                return SponsorLevel.Other;
            }

            return (SponsorLevel)value;
        }
    }
}
