using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Service
{
    public int service_id { get; set; }
    public int? type_id { get; set; }
    public DateTime? service_date { get; set; }
    public int? rsv_id { get; set; }
    public int? staff_id { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Reservation? reservation { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Staff? staff { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ServiceType? servicetype { get; set; }
}
