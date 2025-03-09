using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class ServiceType
{
    public int type_id { get; set; }
    public string? type_name { get; set; }
    public double? type_price { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Service> service { get; set; } = new List<Service>();
}
