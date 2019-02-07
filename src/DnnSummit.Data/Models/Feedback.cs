using System.Collections.Generic;

namespace DnnSummit.Data.Models
{
    public class Feedback
    {
        public string Question { get; set; }
        public string Help { get; set; }
        public int Type { get; set; }
        public bool IsRequired { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}
