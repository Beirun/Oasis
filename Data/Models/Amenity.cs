using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Amenity
{
    public int amenity_id { get; set; }
    public string? amenity_name { get; set; }
    public float? amenity_price { get; set; }
}
