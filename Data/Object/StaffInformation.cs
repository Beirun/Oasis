namespace Oasis.Data.Object
{
    public class StaffInformation
    {
        public int staff_id { get; set; }
        public string? position { get; set; }
        public DateTime? employment_date { get; set; }
        public int user_id { get; set; }
        public string? user_fname { get; set; }
        public string? user_lname { get; set; }
        public string? user_gender { get; set; }
        public DateOnly? user_dob { get; set; }
        public string? user_email { get; set; }
        public string? user_contactno { get; set; }
    }
}
