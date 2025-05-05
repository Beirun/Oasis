
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using Oasis.Data.Object;
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
    }
}
