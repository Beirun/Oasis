using Oasis.Data;
using Oasis.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace Oasis.Library
{
    public class UserServices
    {
        private readonly AppDbContext _context;
        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        //is user male or female
        public async Task<bool> isMale(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.user_id == id);
            if (user.user_gender.ToLower() == "Male".ToLower())
            {
                return true;
            }
            return false;
        }

        //update User
        public async Task updateUser(User user)
        {
            var updatedUser = await _context.User.FirstOrDefaultAsync(u => u.user_id == user.user_id);
            updatedUser = user;
            await _context.SaveChangesAsync();
        }

        //check if email is taken
        public async Task<bool> EmailExist(string email)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.user_email.ToLower() == email.ToLower());
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}
