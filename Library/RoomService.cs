
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
namespace Oasis.Library
{
    public class RoomService
    {
        private readonly AppDbContext _context;
        public RoomService(AppDbContext context)
        {
            _context = context;
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
