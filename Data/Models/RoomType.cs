using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class RoomType
{
    public int type_id { get; set; }
    public string? type_category { get; set; }
    public double? type_price { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Room> room { get; set; } = new List<Room>();
}
