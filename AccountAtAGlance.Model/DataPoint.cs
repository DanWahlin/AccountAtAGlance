using System.ComponentModel.DataAnnotations;

namespace AccountAtAGlance.Model
{
    public class DataPoint
    {
        [Key]
        public long Id { get; set; }

        public string Time { get; set; }
        public long JSTicks { get; set; }
        public decimal Value { get; set; } 
    }
}
