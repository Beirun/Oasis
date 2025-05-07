using Oasis.Data.Models;

namespace Oasis.Data.Object
{
    public class UserGuest
    {
        public int user_id { get; set; }
        public string? user_fname { get; set; }
        public string? user_lname { get; set; }
        public string? user_gender { get; set; }
        
        public DateTime? registration_date { get; set; }
    }
}
