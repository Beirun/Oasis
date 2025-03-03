using System.ComponentModel.DataAnnotations;

namespace Oasis.Data.Models
{
    public class ServiceType
    {
        [Key]
        public int type_id { get; set; }
        public string type_name { get; set; }
        public float type_price { get; set; }
    }
}
