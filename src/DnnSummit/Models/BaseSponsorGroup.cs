namespace DnnSummit.Models
{
    public abstract class BaseSponsorGroup<TElement> : ISponsorGroup
    {
        public TElement DataContext { get; set; }
        public SponsorType Level { get; set; }
    }
}
