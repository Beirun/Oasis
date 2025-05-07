
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
        public async Task<Dictionary<string, double>> GetAverageRatingsPerRoomType()
        {
            var averageRatings = await _context.Review
                .Include(r => r.reservation)  // Include reservation
                    .ThenInclude(rsv => rsv.room)  // Then include room from reservation
                        .ThenInclude(room => room.roomtype)  // Then include roomtype from room
                .Where(r => r.review_rating != null)  // Only include reviews with ratings
                .GroupBy(r => r.reservation.room.roomtype.type_category)  // Group by room type
                .Select(g => new
                {
                    RoomType = g.Key,
                    AverageRating = g.Average(r => r.review_rating.Value)  // Calculate average
                })
                .ToListAsync();

            return averageRatings.ToDictionary(
                x => x.RoomType,
                x => Math.Round(x.AverageRating, 2)  // Round to 2 decimal places
            );
        }
        public async Task<List<RoomTypeReview>> GetRoomReviews()
        {
            var review = await _context.Review
                        .Include(r => r.reservation)
                            .ThenInclude(r => r.room)
                                .ThenInclude(r => r.roomtype) // type_category
                        .Include(r => r.guest)
                            .ThenInclude(g => g.user)
                        .Select(r => new RoomTypeReview
                        {
                            review_id = r.review_id,
                            rsv_id = r.reservation.rsv_id,
                            guest_id = r.guest.guest_id,
                            user_fname = r.guest.user.user_fname,
                            user_lname = r.guest.user.user_lname,
                            review_rating = r.review_rating ?? 0,
                            review_feedback = r.review_feedback ?? string.Empty,
                            review_date = r.review_date ?? default,

                        }
                ).ToListAsync();

            return review;
        }

        public async Task<Dictionary<int, Dictionary<string, int>>> GetRatingCountsByRoomType()
        {
            var ratingCounts = await _context.Review
                .Include(r => r.reservation)
                    .ThenInclude(rsv => rsv.room)
                        .ThenInclude(room => room.roomtype)
                .Where(r => r.review_rating != null && r.review_rating >= 1 && r.review_rating <= 5)
                .GroupBy(r => new
                {
                    Rating = r.review_rating.Value,
                    RoomType = r.reservation.room.roomtype.type_category
                })
                .Select(g => new
                {
                    g.Key.Rating,
                    g.Key.RoomType,
                    Count = g.Count()
                })
                .ToListAsync();

            // Initialize result dictionary with all rating levels
            var result = Enumerable.Range(1, 5).ToDictionary(
                rating => rating,
                rating => new Dictionary<string, int>()
            );

            // Get all room types
            var allRoomTypes = await _context.RoomType
                .Select(rt => rt.type_category)
                .Distinct()
                .ToListAsync();

            // Initialize each rating level with all room types (count = 0)
            foreach (var ratingDict in result.Values)
            {
                foreach (var roomType in allRoomTypes)
                {
                    ratingDict[roomType] = 0;
                }
            }

            // Populate with actual counts
            foreach (var item in ratingCounts)
            {
                if (result.ContainsKey(item.Rating))
                {
                    result[item.Rating][item.RoomType] = item.Count;
                }
            }

            return result;
        }

    }
}
