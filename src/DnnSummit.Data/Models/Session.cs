namespace DnnSummit.Data.Models
{
    public class Session : Entity
    { 
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public Speaker Speaker { get; set; }
        public int Day { get; set; }
        public string TimeSlotName { get; set; }
        public string TimeSlot { get; set; }
        public string Category { get; set; }
        public string VideoLink { get; set; }
        public string Level { get; set; }
        public string Room { get; set; }
    }
}
