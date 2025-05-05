
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using Oasis.Data.Object;
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

        public async Task<Review> GetReviewById(int id)
        {
            return await _context.Review.FirstOrDefaultAsync(r => r.review_id == id);
        }

        public async Task AddReview(Review review)
        {
            _context.Review.Add(review);
            await _context.SaveChangesAsync();
        }
        public async Task<List<RoomTypeReview>> GetRoomTypeReviews(string roomType)
        {
            var review = await _context.Review
                        .Include(r => r.reservation)
                            .ThenInclude(r => r.room)
                                .ThenInclude(r => r.roomtype) // type_category
                                .Where(r => r.reservation.room.roomtype.type_category.ToLower() ==  roomType.ToLower())
                        .Include(r=> r.guest)
                            .ThenInclude(g => g.user)
                        .Select(r => new RoomTypeReview
                        {
                            review_id = r.review_id,
                            rsv_id = r.reservation.rsv_id,
                            guest_id  = r.guest.guest_id,
                            user_fname = r.guest.user.user_fname,
                            user_lname = r.guest.user.user_lname,
                            review_rating = r.review_rating ?? 0,
                            review_feedback = r.review_feedback ?? string.Empty,
                            review_date = r.review_date ?? default,

                        }
                ).ToListAsync();

            return review;
        }
        
    }
}
