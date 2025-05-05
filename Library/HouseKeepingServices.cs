
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using Oasis.Data.Object;
namespace Oasis.Library
{
    public class HouseKeepingServices
    {
        private readonly AppDbContext _context;
        public HouseKeepingServices( AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<HouseKeeping>> GetHouseKeeping()
        {
            return await _context.HouseKeeping.ToListAsync();
        }
        public async Task AddHouseKeeping(HouseKeeping houseKeeping)
        {
            _context.HouseKeeping.Add(houseKeeping);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateHouseKeeping(int roomId)
        {
            var houseKeeping = await _context.HouseKeeping.FirstOrDefaultAsync(r => r.room_id == roomId && r.housekeeping_endtime == null);
            if (houseKeeping != null)
            {
                houseKeeping.housekeeping_endtime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<HouseKeepingRoom>> GetHouseKeepingRooms(string type_category)
        {
            var houseKeepingRooms = await _context.Room
                .Include(room => room.roomtype)
                .Include(room => room.housekeeping)
                .Where(room => room.roomtype != null &&
                              room.roomtype.type_category.ToLower() == type_category.ToLower() &&
                              (room.room_status == "Needs Cleaning" || room.room_status == "Being Cleaned"))
                .Select(room => new
                {
                    Room = room,
                    ActiveHousekeeping = room.housekeeping.FirstOrDefault(hk => hk.housekeeping_endtime == null),
                    HasNoHousekeepingRecords = !room.housekeeping.Any()
                })
                .Where(x => (x.ActiveHousekeeping != null) ||
                           (x.HasNoHousekeepingRecords && x.Room.room_status == "Needs Cleaning"))
                .Select(x => new HouseKeepingRoom
                {
                    room_id = x.Room.room_id,
                    room_no = x.Room.room_no ?? 0,
                    room_status = x.Room.room_status ?? string.Empty,
                    staff_id = x.ActiveHousekeeping != null ? x.ActiveHousekeeping.staff_id ?? 0 : 0,
                    housekeeping_starttime = x.ActiveHousekeeping.housekeeping_starttime,
                    housekeeping_endtime = x.ActiveHousekeeping.housekeeping_endtime
                })
                .ToListAsync();

            return houseKeepingRooms;
        }
        public async Task<List<HouseKeepingRoom>> GetRecentlyCleanedRooms(int? limit = null, string? type_category = null)
        {
            var query = _context.HouseKeeping
                .Include(hk => hk.room)
                    .ThenInclude(room => room.roomtype)
                .Include(hk => hk.staff) // Include staff if you need staff info later
                .Where(hk => hk.housekeeping_endtime != null); // Only cleaned rooms

            // Apply type_category filter if provided
            if (!string.IsNullOrEmpty(type_category))
            {
                query = query.Where(hk => hk.room != null &&
                                        hk.room.roomtype != null &&
                                        hk.room.roomtype.type_category == type_category);
            }

            // Order by most recently cleaned first
            query = query.OrderByDescending(hk => hk.housekeeping_endtime);

            // Apply limit if provided
            if (limit.HasValue)
            {
                query = query.Take(limit.Value);
            }

            var recentlyCleanedRooms = await query
                .Select(hk => new HouseKeepingRoom
                {
                    room_id = hk.room_id ?? 0,
                    staff_id = hk.staff_id ?? 0,
                    room_no = hk.room.room_no ?? 0,
                    room_status = hk.room.room_status ?? string.Empty,
                    housekeeping_starttime = hk.housekeeping_starttime,
                    housekeeping_endtime = hk.housekeeping_endtime
                })
                .ToListAsync();

            return recentlyCleanedRooms;
        }
    }
}
