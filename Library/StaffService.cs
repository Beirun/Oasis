
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using Oasis.Data.Object;
namespace Oasis.Library
{
    public class StaffService
    {
        private readonly AppDbContext _context;
        public StaffService(AppDbContext context)
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
                    user_id = s.user.user_id,
                    user_fname = s.user.user_fname,
                    user_lname = s.user.user_lname,
                    user_gender = s.user.user_gender,
                    user_dob = s.user.user_dob,
                    user_email = s.user.user_email,
                    user_contactno = s.user.user_contactno
                })
                .ToListAsync();
        }

        public async Task<bool> checkPassword(string email, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.user_email == email && u.user_password == password);
            if (user != null)
            {
                return true;
            }
            return false;
        }

    }
}
