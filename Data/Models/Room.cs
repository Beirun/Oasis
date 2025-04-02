using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Room
{
    public int room_id { get; set; }
    public int? room_no { get; set; }
    public int? type_id { get; set; }
    public string? room_status { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<HouseKeeping> housekeeping { get; set; } = new List<HouseKeeping>();
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Reservation> reservation { get; set; } = new List<Reservation>();
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Review> review { get; set; } = new List<Review>();
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual RoomType? roomtype { get; set; }
}
