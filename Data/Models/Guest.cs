using System.ComponentModel.DataAnnotations;

namespace Oasis.Data.Models
{
    public class Guest
    {
        [Key]
        public int guest_id { get; set; }

        public string? guest_fname { get; set; }
        public string? guest_lname { get; set; }
        public string? guest_gender { get; set; }
        public DateOnly? guest_dob { get; set; }
        public string? guest_email { get; set; }
        public string? guest_contactno { get; set; }
        public string? guest_password { get; set; }
    }
}
