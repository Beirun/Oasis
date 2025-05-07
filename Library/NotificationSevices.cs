
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
                // No need to check notif_id - DB will handle it
                _context.Notification.Add(notification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddNotification: {ex.Message}");
                throw;
            }
        }
        public async Task AddNotificationToStaffByPosition(Notification notification, string position)
        {
            try
            {
                var staffs = await _context.Staff
                    .Where(s => s.position.ToLower() == position.ToLower())
                    .ToListAsync();

                foreach (var staff in staffs)
                {
                    // Create a NEW notification for each staff member
                    var staffNotification = new Notification
                    {
                        notif_title = notification.notif_title,
                        notif_content = notification.notif_content,
                        notif_date = notification.notif_date,
                        notif_status = notification.notif_status,
                        user_id = staff.staff_id
                    };

                    _context.Notification.Add(staffNotification);
                }

                await _context.SaveChangesAsync(); // Save once after the loop
            }
            catch (Exception ex)
            {
                // Log the exception instead of silently swallowing it
                Console.WriteLine($"Error in AddNotificationToStaffByPosition: {ex.Message}");
                throw; // Re-throw or handle appropriately
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
