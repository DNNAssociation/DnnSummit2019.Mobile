using System.Collections.Generic;

namespace DnnSummit.Models
{
    public interface ISponsorGroup
    {
        SponsorType Level { get; }
    }

    public abstract class BaseSponsorGroup<TElement> : ISponsorGroup
    {
        public TElement DataContext { get; set; }
        public SponsorType Level { get; set; }
    }

    public class TitlePlatinumSponsor : BaseSponsorGroup<Sponsor>
    {
    }

    public class GeneralSponsor : BaseSponsorGroup<IEnumerable<Sponsor>>
    {
    }

    public class Sponsor
    {
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public string Homepage { get; set; }
        public SponsorType Level { get; set; }
    }

    public enum SponsorType
    {
        Title,
        Platinum,
        Gold,
        Silver,
        Bronze
    }
}
