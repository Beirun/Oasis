namespace Oasis.Data.Object
{
    public class GuestBooking
    {
        public int rsv_id { get; set; }
        public int room_id { get; set; }
        public int review_id { get; set; }
        public int room_no { get; set; }
        public string type_category { get; set; }
        public DateOnly rsv_checkin { get; set; }
        public DateOnly rsv_checkout { get; set; }
        public string rsv_status { get; set; }
        public double payment_amount { get; set; }
    }
}
