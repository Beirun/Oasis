namespace Oasis.Data.Object
{
    public class RoomTypeReview
    {
        public int review_id { get; set; }
        public int? rsv_id { get; set; }
        public int? guest_id { get; set; }
        public string user_fname { get; set; }
        public string user_lname { get; set; }
        public DateTime? review_date { get; set; }
        public int? review_rating { get; set; }
        public string? review_feedback { get; set; }
    }
}
