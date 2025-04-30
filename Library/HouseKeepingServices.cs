
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
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
        
        public async Task UpdateHouseKeeping(HouseKeeping houseKeeping)
        {
            var existingHouseKeeping = await _context.HouseKeeping.FindAsync(houseKeeping.housekeeping_id);
            if (existingHouseKeeping != null)
            {
                existingHouseKeeping.room_id = houseKeeping.room_id;
                existingHouseKeeping.staff_id = houseKeeping.staff_id;
                existingHouseKeeping.housekeeping_date = houseKeeping.housekeeping_date;
                await _context.SaveChangesAsync();
            }
        }
    }
}
