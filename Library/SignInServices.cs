
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
namespace Oasis.Library
{
    public class SignInServices
    {
        private readonly AppDbContext _context;
        public SignInServices(AppDbContext context)
        {
            _context = context;
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
        public async Task<bool> checkPassword(string email, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.user_email == email && u.user_password == password);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<string> getUserType(string email)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.user_email == email);
            if (user != null)
            {
                if (user.user_type == "Guest") return "Guest";
                else
                {
                    var staff = await _context.Staff.FirstOrDefaultAsync(s => s.staff_id == user.user_id);
                    return staff?.position?? "";
                }
            }
            return "";    
        }

        public async Task<KeyValuePair<bool, string>> checkUser(string email, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.user_email == email);
            if (user != null)
            {
                if(user.user_password != password)
                {
                   return new KeyValuePair<bool, string>(false, "Incorrect Password");

                }

                if (user.user_type == "Guest")
                    
                    return new KeyValuePair<bool, string>(true, "Guest");
                else
                {
                    var staff = await _context.Staff.FirstOrDefaultAsync(s => s.staff_id == user.user_id);
                    return new KeyValuePair<bool, string>(true, staff?.position?? "");
                }
            }
            return new KeyValuePair<bool, string>(false, "Email doesn't exist");
        }
        public async Task<User> getUser(string email)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.user_email == email);
            return user;
        }
        
    }
}
