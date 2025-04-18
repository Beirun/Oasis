﻿
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
namespace Oasis.Library
{

    public class GuestServices
    {
        private readonly AppDbContext _context;
        public GuestServices( AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegisterGuest(User user)
        {
            try { 

                Guest guest = new Guest();
                user.user_type = "Guest";
                _context.User.Add(user);
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
        public async Task<List<Guest>> GetGuests()
        {
            return await _context.Guest.ToListAsync();
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
