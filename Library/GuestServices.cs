
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using Oasis.Data.Object;
using System.Globalization;
namespace Oasis.Library
{

    public class GuestServices
    {
        private readonly AppDbContext _context;
        public GuestServices( AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> getGuests()
        {

            return await _context.User.Where(u => u.user_type == "Guest").ToListAsync();

        }
        public async Task<List<UserGuest>> getUserGuests()
        {

            return await _context.User
                .Include(g => g.guest)
                .Where(u => u.user_type == "Guest")
                .Select(u => new UserGuest
                {
                    user_id = u.user_id,
                    user_fname = u.user_fname,
                    user_lname = u.user_lname,
                    user_gender= u.user_gender,
                    registration_date = u.guest.registration_date

                }
                    
                )
                .ToListAsync();

        }
        public async Task<User> getUserFromFirstNameLastName(string fname, string lname)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(u => u.user_fname == fname && u.user_lname == lname && u.user_type == "Guest");
            return existingUser;
        }
        public async Task<bool> RegisterGuest(User user)
        {
            try { 

                Guest guest = new Guest();
                user.user_type = "Guest";
                //check if user_fname and user_lname is already in the database
                var existingUser = await getUserFromFirstNameLastName(user.user_fname, user.user_lname);
                if (existingUser == null)
                {
                _context.User.Add(user);

                }
                else
                {
                    return true;
                }
                    await _context.SaveChangesAsync();
                guest.guest_id = user.user_id;
                Console.WriteLine("User: ", user.user_id);
                guest.registration_date = DateTime.Now;
                Console.WriteLine("Guest: ",System.Text.Json.JsonSerializer.Serialize(guest));

                _context.Guest.Add(guest);
                await _context.SaveChangesAsync();

            }catch {
                return false;
            }

            return true;
        }
      
        public async Task<bool> checkEmail(string email)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.user_email == email);
            if (user != null)
            {
                return true;
            }
            return false;
        }
       
        public async Task<Dictionary<string, int>> GetMonthlyGuestRegistrations()
        {
            // Calculate date range (past 12 months from current date)
            var endDate = DateTime.Now;
            var startDate = endDate.AddMonths(-11).Date; // 12 months total (inclusive)

            // Step 1: Fetch raw data from the database (grouped by Year & Month)
            var monthlyData = await _context.Guest
                .Where(g => g.registration_date != null &&
                            g.registration_date >= startDate &&
                            g.registration_date <= endDate)
                .GroupBy(g => new {
                    Year = g.registration_date.Value.Year,
                    Month = g.registration_date.Value.Month
                })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    GuestCount = g.Count()
                })
                .ToListAsync();

            // Step 2: Generate all months in the past 12 months (including those with zero registrations)
            var allMonthsInRange = Enumerable.Range(0, 12)
                .Select(offset => endDate.AddMonths(-offset))
                .Select(date => new DateTime(date.Year, date.Month, 1))
                .Distinct()
                .OrderBy(date => date)
                .ToList();

            // Step 3: Combine with actual data and use abbreviated month format
            var monthlyGuestCounts = allMonthsInRange
                .GroupJoin(monthlyData,
                    date => new { date.Year, date.Month },
                    data => new { data.Year, data.Month },
                    (date, data) => new
                    {
                        Date = date,
                        Count = data.Select(x => x.GuestCount).FirstOrDefault()
                    })
                .ToDictionary(
                    x => x.Date.ToString("MMM yyyy", CultureInfo.InvariantCulture), // "Dec 2025" format
                    x => x.Count
                );

            return monthlyGuestCounts;
        }
    }
}
