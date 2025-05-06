
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using Oasis.Data.Object;
namespace Oasis.Library
{
    public class RoomServices
    {
        private readonly AppDbContext _context;
        public RoomServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> getRooms()
        {
            var rooms = await _context.Room.ToListAsync();
            return rooms;
        }

        // New method to get rooms with type categories
        public async Task<List<ReceptionistRoomInventory>> GetRoomInventory()
        {
            var roomsWithTypes = await _context.Room
                .Include(r => r.roomtype) // Include the RoomType navigation property
                .Select(r => new ReceptionistRoomInventory
                {
                    room_id = r.room_id,
                    room_no = r.room_no ?? 0, // Using null-coalescing operator for nullable int
                    type_category = r.roomtype != null ? r.roomtype.type_category ?? "Unknown" : "Unknown",
                    type_price = r.roomtype.type_price ?? 0,
                    room_status = r.room_status ?? "Unknown"
                })
                .ToListAsync();

            return roomsWithTypes;
        }

        public async Task setRoomStatus(int roomId, string status)
        {
            var room = await _context.Room.FirstOrDefaultAsync(r => r.room_id == roomId);
            if (room != null)
            {
                room.room_status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RoomType> getRoomType(string roomType)
        {
            var roomTypeObj = await _context.RoomType.FirstOrDefaultAsync(r => r.type_category.ToLower() == roomType.ToLower());
            return roomTypeObj;
        }

        public async Task<Room> getRandomRoomFromType(string roomType)
        {
            var rooms = await _context.Room.Where(r => r.roomtype!.type_category.ToLower() == roomType.ToLower() && r.room_status == "Available").ToListAsync();
            return rooms[new Random().Next(rooms.Count)];
        }
        public async Task<int> GetNumberOfRoomsByStatus(string status)
        {
            var rooms = await _context.Room.Where(r => r.room_status.ToLower() == status.ToLower()).ToListAsync();
            return rooms.Count;
        }

        public async Task<int> GetNumberOfRoomsByStatusAndType(string status, string roomType)
        {
            var rooms = await _context.Room.Where(r => r.room_status.ToLower() == status.ToLower() && r.roomtype!.type_category.ToLower() == roomType.ToLower()).ToListAsync();
            return rooms.Count;
        }

        public async Task<List<Room>> GetRoomsByType(string roomType)
        {
            var rooms = await _context.Room.Where(r => r.roomtype!.type_category.ToLower() == roomType.ToLower()).ToListAsync();
            return rooms;
        }
        public async Task UpdateRoomStatus(int roomId, string status)
        {
            var room = await _context.Room.FirstOrDefaultAsync(r => r.room_id == roomId);
            if (room != null)
            {
                room.room_status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Dictionary<string, int>> GetNumberOfBookedRoomsPerType()
        {
            var rooms = await _context.Room
                .Where(r => r.room_status == "Unavailable" || r.room_status == "Reserved")
                .GroupBy(r => r.roomtype!.type_category)
                .Select(g => new { Type = g.Key, Count = g.Count() })
                .ToListAsync();

            return rooms.ToDictionary(r => r.Type, r => r.Count);
        }
        public async Task<Dictionary<string, int>> GetTotalNumberOfReservationsPerType()
        {
            var reservations = await _context.Reservation
                .Include(r => r.room)
                    .ThenInclude(room => room.roomtype)
                .GroupBy(r => r.room.roomtype.type_category)  // Group by room type category
                .Select(g => new
                {
                    Type = g.Key,
                    Count = g.Count()  // Count reservations per type
                })
                .ToListAsync();

            return reservations.ToDictionary(r => r.Type, r => r.Count);
        }

        public async Task<double> GetOccupancyPercentage()
        {
            // Get total number of rooms
            int totalRooms = await _context.Room.CountAsync();

            if (totalRooms == 0)
                return 0; // Avoid division by zero if no rooms exist

            // Get count of occupied rooms (status != "Available")
            int occupiedRooms = await _context.Room
                .CountAsync(r => r.room_status != "Available");

            // Calculate percentage
            double percentage = (double)occupiedRooms / totalRooms * 100;

            return percentage;
        }
       
    }
}

