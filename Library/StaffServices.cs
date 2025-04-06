
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using Oasis.Data.Object;
namespace Oasis.Library
{
    public class StaffServices
    {
        private readonly AppDbContext _context;
        public StaffServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StaffInformation>> GetStaffs()
        {
            return await _context.Staff
                .Include(s => s.user)
                .Where(s => s.position != "Admin") // Filtering out Admins
                .Select(s => new StaffInformation
                {
                    staff_id = s.staff_id,
                    position = s.position,
                    employment_date = s.employment_date,
                    user_id = s.user!.user_id,
                    user_fname = s.user.user_fname,
                    user_lname = s.user.user_lname,
                    user_gender = s.user.user_gender,
                    user_dob = s.user.user_dob,
                    user_email = s.user.user_email,
                    user_contactno = s.user.user_contactno
                })
                .ToListAsync();
        }

        public async Task<bool> AddStaff(User user, string staffPosition)
        {
            try
            {

                Staff newStaff = new Staff();
                user.user_type = "Staff";
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                newStaff.position = staffPosition;
                newStaff.staff_id = user.user_id;
                Console.WriteLine("User: ", user.user_id);
                newStaff.employment_date = DateTime.Now;
                //Console.WriteLine("Guest: ", System.Text.Json.JsonSerializer.Serialize(guest));

                _context.Staff.Add(newStaff);
                await _context.SaveChangesAsync();

            }
            catch
            {
                return false;
            }

            return true;
        }


        public async Task<bool> EditStaff(User user, string staffPosition)
        {
            try
            {
                // Find existing user
                var existingUser = await _context.User.FindAsync(user.user_id);
                if (existingUser == null)
                {
                    return false; // User not found
                }

                // Update user details
                existingUser.user_fname = user.user_fname;
                existingUser.user_lname = user.user_lname;
                existingUser.user_gender = user.user_gender;
                existingUser.user_dob = user.user_dob;
                existingUser.user_email = user.user_email;
                existingUser.user_contactno = user.user_contactno;

                // Find existing staff record
                var existingStaff = await _context.Staff.FindAsync(user.user_id);
                if (existingStaff == null)
                {
                    return false; // Staff record not found
                }

                // Update staff position
                existingStaff.position = staffPosition;

                // Save changes
                await _context.SaveChangesAsync();
            }
            catch
            {
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
