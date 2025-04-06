
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
        
    }
}
