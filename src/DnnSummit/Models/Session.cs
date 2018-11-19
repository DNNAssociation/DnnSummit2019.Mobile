namespace DnnSummit.Models
{
    public class Session
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public SessionTrack Track { get; set; }
        public Speaker Speaker { get; set; }
    }
}
