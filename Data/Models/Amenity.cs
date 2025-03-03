using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis.Data.Models
{
    public class Amenity
    {
        [Key]
        public int amenity_id { get; set; }

        public int rsv_id { get; set; }

        public int item_id { get; set; }

        [ForeignKey("rsv_id")]
        public Reservation reservation { get; set; }

        [ForeignKey("item_id")]
        public AmenityItem amenityItem { get; set; }
        
    }
}
