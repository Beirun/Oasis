namespace Oasis.Data.Object
{
    public class HouseKeepingRoom
    {
        public int room_id { get; set; }
        public int staff_id { get; set; }
        public string? user_fname { get; set; }
        public string? user_lname { get; set; }
        public string? user_gender { get; set; }
        public int room_no { get; set; }
        public string room_status { get; set; }
        public DateTime? housekeeping_starttime { get; set; }
        public DateTime? housekeeping_endtime { get; set; }

    }
}
