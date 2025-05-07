namespace Oasis.Data.Object
{
    public class Payment
    {
        public int payment_id { get; set; }
        public string user_gender { get; set; }
        public string user_email { get; set; }
        public string user_fname { get; set; }
        public string user_lname { get; set; }
        public int room_no { get; set; }
        public string type_category { get; set; }
        public string staff_fname { get; set; }
        public string staff_lname { get; set; }
        public double payment_amount { get; set; }
        public DateTime payment_date { get; set; }
    }
}
