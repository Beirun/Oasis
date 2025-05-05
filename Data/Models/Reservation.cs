using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Reservation
{
    public int rsv_id { get; set; }
    public int? room_id { get; set; }
    public int? guest_id { get; set; }
    public DateOnly? rsv_checkin { get; set; }
    public DateOnly? rsv_checkout { get; set; }
    public int? payment_id { get; set; }
    public string? rsv_status { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Payment? payment { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Guest? guest { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Room? room { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Review? review { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Service> service { get; set; } = new List<Service>();
}
