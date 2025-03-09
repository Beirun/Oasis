using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class HouseKeeping
{
    public int housekeeping_id { get; set; }
    public int? room_id { get; set; }
    public int? staff_id { get; set; }
    public DateTime? housekeeping_date { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Room? room { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Staff? staff { get; set; }

}
