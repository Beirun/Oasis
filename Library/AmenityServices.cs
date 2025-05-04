using Oasis.Data.Models;
using Oasis.Data;
using Oasis.Data.Object;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oasis.Library
{
    public class AmenityServices
    {
        private readonly AppDbContext _context;
        public AmenityServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoomAmenity>> GetAmenitiesByRoomTypeAsync(string roomType)
        {
            var amenities = await _context.RoomType
                .Where(rt => rt.type_category.ToLower() == roomType.ToLower())
                .SelectMany(rt => rt.amenity)
                .Include(a => a.amenityItem)
                .Include(a => a.roomType)
                .Select(a => new RoomAmenity
                {
                    amenity_id = a.amenity_id,
                    type_category = a.roomType.type_category,
                    amenity_name = a.amenityItem.amenity_name,
                    amenity_price = a.amenityItem.amenity_price
                })
                .ToListAsync();

            return amenities;
        }
    }
}