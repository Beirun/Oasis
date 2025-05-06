namespace Oasis.Data.Object
{
    public class Booking
    {
        public int rsv_id { get; set; }
        public int user_id { get; set; }
        public string user_email { get; set; }
        public string user_fname { get; set; }
        public string user_lname { get; set; }
        public int room_no { get; set; }
        public string type_category { get; set; }
        public DateOnly rsv_checkin { get; set; }
        public DateOnly rsv_checkout { get; set; }
        public string rsv_status { get; set; }
        public double payment_amount { get; set; }
    }
}
