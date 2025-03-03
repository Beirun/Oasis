using System.ComponentModel.DataAnnotations;

namespace Oasis.Data.Models
{
    public class Staff
    {
        [Key]
        public int staff_id { get; set; }
        public string staff_fname { get; set; }
        public string staff_lname { get; set; }
        public string staff_position { get; set; }
        public string staff_email { get; set; }
        public string staff_contactno { get; set; }
        public string staff_gender { get; set; }
        public string staff_dob { get; set; }
        public string staff_password { get; set; }
    }
}
