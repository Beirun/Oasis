using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis.Data.Models
{
    public class Review
    {
        [Key]
        public int review_id { get; set; }
        public int room_id { get; set; }
        public int guest_id { get; set; }
        public DateOnly review_date { get; set; }
        public int review_rating { get; set; }
        public string review_feedback { get; set; }

        [ForeignKey("room_id")]
        public Room room { get; set; }
        [ForeignKey("guest_id")]
        public Guest guest { get; set; }
    }
}
