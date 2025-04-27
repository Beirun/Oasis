
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

        public async Task<List<Payment>> GetPayments()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task<int> AddPayment(string paymentMethod, double amount, DateTime paymentDate)
        {
            Payment payment = new Payment();
            payment.payment_amount = amount;
            payment.payment_method = paymentMethod;
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
