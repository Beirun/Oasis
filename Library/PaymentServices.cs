
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
namespace Oasis.Library
{
    public class PaymentServices
    {
        private readonly AppDbContext _context;
        public PaymentServices( AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Oasis.Data.Object.Payment>> GetPayments()
        {
            var payments = await _context.Payment
                        .Include(p => p.reservation)
                            .ThenInclude(r => r.room)
                                .ThenInclude(room => room.roomtype)
                        .Include(p => p.reservation)
                            .ThenInclude(r => r.guest)
                                .ThenInclude(g => g.user)
                        .Include(p => p.staff)  // Still include staff even if it might be null
                            .ThenInclude(s => s.user)
                        .Where(p => p.reservation != null)  // Removed staff null check from Where clause
                        .Select(p => new Oasis.Data.Object.Payment
                        {
                            payment_id = p.payment_id,
                            user_email = p.reservation.guest.user.user_email,
                            user_fname = p.reservation.guest.user.user_fname,
                            user_lname = p.reservation.guest.user.user_lname,
                            room_no = p.reservation.room.room_no ?? 0,
                            type_category = p.reservation.room.roomtype.type_category,
                            staff_fname = p.staff != null ? p.staff.user.user_fname : "",  // Handle null staff
                            staff_lname = p.staff != null ? p.staff.user.user_lname : "", // Handle null staff
                            payment_amount = p.payment_amount ?? 0,
                            payment_date = p.payment_date ?? DateTime.MinValue
                        })
                        .ToListAsync();

            return payments;
            //return await _context.Payment.ToListAsync();
        }

        public async Task<int> AddPayment(double amount, DateTime paymentDate)
        {
            Payment payment = new Payment();
            payment.payment_amount = amount;
            payment.payment_date = paymentDate;
            _context.Payment.Add(payment);
            await _context.SaveChangesAsync();
            return payment.payment_id;
        }

        public async Task<double> GetTotalIncome()
        {
            var totalIncome = await _context.Payment.SumAsync(p => p.payment_amount);
            if (totalIncome != null)
            {
                return totalIncome.Value;
            }
            return 0;
        }
        
    }
}
