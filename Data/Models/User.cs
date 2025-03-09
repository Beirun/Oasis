using System;
using System.Collections.Generic;

namespace Oasis.Data.Models;

public partial class User
{
    public int user_id { get; set; }
    public string? user_fname { get; set; }
    public string? user_lname { get; set; }
    public string? user_gender { get; set; }
    public DateOnly? user_dob { get; set; }
    public string? user_email { get; set; }
    public string? user_contactno { get; set; }
    public string? user_password { get; set; }
    public string? user_type { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Guest? guest { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<Notification> notification { get; set; } = new List<Notification>();
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Staff? staff { get; set; }
}
