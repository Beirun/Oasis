using System.ComponentModel.DataAnnotations;

namespace Oasis.Data.Models
{
    public class Discount
    {
        [Key]
        public int discount_id { get; set; }
        public string discount_name { get; set; }
        public float discount_rate { get; set; }
    }
}
