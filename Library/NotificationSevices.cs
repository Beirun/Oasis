
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
        private async Task<List<Notification>> GetUserNotifications(int userId)
        {
            List<Notification> notifications = await _context.Notification.Where(n => n.user_id == userId).ToListAsync();
            return notifications;
        }

        private async Task<bool> AddNotification(Notification notification)
        {
            try
            { 
                _context.Notification.Add(notification);
                await _context.SaveChangesAsync();
            
            }
            catch 
            {
                return false;
            }
            return true;
        }
        private async Task<bool> UpdateNotification(Notification notification)
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
