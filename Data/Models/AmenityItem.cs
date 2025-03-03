using System.ComponentModel.DataAnnotations;

namespace Oasis.Data.Models
{
    public class AmenityItem
    {
        [Key]
        public int item_id { get; set; }
        public string item_name { get; set; }
        public int item_price { get; set; }
    }
}
