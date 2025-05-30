﻿using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class Payment
{
    public int payment_id { get; set; }
    public double? payment_amount { get; set; }
    public DateTime? payment_date { get; set; }
    public int? staff_id { get; set; }
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Staff? staff { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Reservation? reservation { get; set; }
}
