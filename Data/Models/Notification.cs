using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Notification
{
    public int notif_id { get; set; }
    public string? notif_title { get; set; }
    public DateTime? notif_date { get; set; }
    public string? notif_content { get; set; }
    public string? notif_status { get; set; }
    public int? user_id { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual User? user { get; set; }

}
