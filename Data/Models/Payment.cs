using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis.Data.Models
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        public float payment_amount { get; set; }
        public int? discount_id { get; set; }
        public string payment_method { get; set; }
        public DateTime? payment_date { get; set; }
        public int staff_id { get; set; }
        [ForeignKey("staff_id")]
        public Staff staff { get; set; }
        [ForeignKey("discount_id")]
        public Discount discount { get; set; }
    }
}
