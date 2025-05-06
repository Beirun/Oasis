
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
namespace Oasis.Library
{
    public class NotificationSevices
    {
        private readonly AppDbContext _context;
        public NotificationSevices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Notification>> GetUserNotifications(int userId)
        {
            List<Notification> notifications = await _context.Notification.Where(n => n.user_id == userId).ToListAsync();
            return notifications;
        }

        public async Task AddNotification(Notification notification)
        {
            try
            { 
                _context.Notification.Add(notification);
                await _context.SaveChangesAsync();
            
            }
            catch 
            {
                return;
            }
        }
        public async Task AddNotificationToStaffByPosition(Notification notification, string position)
        {
            try
            {
                var staffs = await _context.Staff.Where(s => s.position.ToLower() == position.ToLower()).ToListAsync();
                    Console.WriteLine($"Staff: {System.Text.Json.JsonSerializer.Serialize(staffs)}");
                foreach (var staff in staffs)
                {
                    notification.user_id = staff.staff_id;
                    _context.Notification.Add(notification);
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                return;
            }
        }
        public async Task<bool> UpdateNotification(Notification notification)
        {
            try
            {
                var existingNotification = await _context.Notification.FirstOrDefaultAsync(n => n.notif_id == notification.notif_id);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
