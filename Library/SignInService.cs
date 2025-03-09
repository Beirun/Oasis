
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
namespace Oasis.Library
{
    public class SignInService
    {
        private readonly AppDbContext _context;
        public SignInService(AppDbContext context)
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

    }
}
