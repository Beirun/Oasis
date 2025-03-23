using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Guest
{
    public int guest_id { get; set; }
    public DateTime? registration_date { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]

    public virtual User? user { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Reservation> reservation { get; set; } = new List<Reservation>();
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Review> review { get; set; } = new List<Review>();
}
