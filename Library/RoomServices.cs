
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
        // public async Task<bool> checkEmail(string email)
        // {
        //     var user = await _context.User.FirstOrDefaultAsync(u => u.user_email == email);
        //     if (user != null)
        //     {
        //         return true;
        //     }
        //     return false;
        // }
        // public async Task seedRoom(){
        //     var rooms = await _context.Room.ToListAsync();
        //     if (!rooms.Any()) // More efficient than Count() == 0
        //     {
        //         List<Room> newRooms = new List<Room>();

        //         for (int i = 0; i < 15; i++)
        //         {
        //             int roomNumber = (i + 1) * 100;
        //             for (int j = 0; j < 15; j++)
        //             {
        //                 newRooms.Add(new Room
        //                 {
        //                     room_no = roomNumber + (j + 1),
        //                     type_id = j <= 7 ? 1 : j <= 11 ? 2 : 3,
        //                     room_status = "Available",
        //                 });
        //             }
        //         }

        //         _context.Room.AddRange(newRooms); // Batch insertion
        //         await _context.SaveChangesAsync();
        //     }

        // }
    }
}

