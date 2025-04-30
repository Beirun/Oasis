using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Staff
{
    public int staff_id { get; set; }
    public string? position { get; set; }
    public DateTime? employment_date { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Payment> payment { get; set; } = new List<Payment>();
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<HouseKeeping> housekeeping { get; set; } = new List<HouseKeeping>();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Service> service { get; set; } = new List<Service>();
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User? user { get; set; }
}
