using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class AmenityItem
{
    public int item_id { get; set; }
    public string? amenity_name { get; set; }
    public float? amenity_price { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]

    public virtual ICollection<Amenity> amenity { get; set; } = new List<Amenity>();

}
