namespace Oasis.Data.Models
{
    public class Amenity
    {
        public int amenity_id { get; set; }
        public int type_id { get; set; }
        public int item_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AmenityItem amenityItem { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]

        public virtual RoomType roomType { get; set; } = null!;
    }
}
