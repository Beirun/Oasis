using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Discount
{
    public int discount_id { get; set; }
    public string? discount_name { get; set; }
    public double? discount_rate { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Payment> payment { get; set; } = new List<Payment>();
}
