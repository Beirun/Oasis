using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oasis.Data.Models
{
    public class Room
    {
        [Key]
        public int room_id { get; set; }
        public int room_no { get; set; }
        public int type_id { get; set; }
        public int room_status { get; set; }
        public int? guest_id { get; set; }

        [ForeignKey("type_id")]
        public RoomType RoomType { get; set; }
        [ForeignKey("guest_id")]
        public Guest? Guest { get; set; }
        }
}
