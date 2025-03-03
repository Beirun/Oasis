using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis.Data.Models
{
    public class Service
    {
        [Key]
        public int service_id { get; set; }
        public int type_id { get; set; }
        public DateTime service_date { get; set; }
        public int rsv_id { get; set; }
        public int staff_id { get; set; }

        [ForeignKey("staff_id")]
        public Staff staff { get; set; }
        [ForeignKey("type_id")]
        public ServiceType serviceType { get; set; }
        [ForeignKey("rsv_id")]
        public Reservation reservation { get; set; }
    }
}
