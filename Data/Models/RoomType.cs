using System.ComponentModel.DataAnnotations;

namespace Oasis.Data.Models
{
    public class RoomType
    {
        [Key]
        public int type_id { get; set; }
        public string type_category { get; set; }
        public float type_price { get; set; }
    }
}
