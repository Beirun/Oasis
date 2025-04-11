
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
namespace Oasis.Library
{
    public class ReviewServices
    {
        private readonly AppDbContext _context;
        public ReviewServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetReviews()
        {
            return await _context.Review.ToListAsync();
        }

        public async Task AddReview(Review review)
        {
            _context.Review.Add(review);
            await _context.SaveChangesAsync();
        }
        public async Task GetAverageRating(string roomType)
        {

        }
    }
}
