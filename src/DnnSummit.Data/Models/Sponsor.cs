namespace DnnSummit.Data.Models
{
    public class Sponsor
    {
        public string Name { get; set; }
        public string Homepage { get; set; }
        public byte[] Image { get; set; }
        public SponsorLevel Level { get; set; }
    }
}
