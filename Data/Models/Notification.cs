using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis.Data.Models
{
    public class Notification
    {
        [Key]
        public int notif_id { get; set; }
        public string notif_title { get; set; }
        public string notif_date { get; set; }
        public string notif_content { get; set; }
        public string notif_status { get; set; }
        public int? guest_id { get; set; }
        public int? staff_id { get; set; }
        [ForeignKey("guest_id")]
        public Guest guest { get; set; }
        [ForeignKey("staff_id")]
        public Staff staff { get; set; }

    }
}
