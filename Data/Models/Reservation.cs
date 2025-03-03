using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis.Data.Models
{
    public class Reservation
    {
        [Key]
        public int rsv_id { get; set; }
        public int room_id { get; set; }
        public int guest_id { get; set; }
        public DateOnly rsv_checkin { get; set; }
        public DateOnly rsv_checkout { get; set; }
        public int payment_id { get; set; }
        public string rsv_status { get; set; }

        [ForeignKey("guest_id")]
        public Guest guest { get; set; }
        [ForeignKey("room_id")]
        public Room room { get; set; }
        [ForeignKey("payment_id")]
        public Payment payment { get; set; }
    }
}
