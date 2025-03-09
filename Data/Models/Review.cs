using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Review
{
    public int review_id { get; set; }
    public int? room_id { get; set; }
    public int? guest_id { get; set; }
    public DateTime? review_date { get; set; }
    public int? review_rating { get; set; }
    public string? review_feedback { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Guest? guest { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]

    public virtual Room? room { get; set; }
}
