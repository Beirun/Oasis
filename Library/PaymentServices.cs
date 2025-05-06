
using ChartJs.Blazor.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
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

        public async Task<int> AddPayment(double amount, DateTime paymentDate, int staff_id)
        {
            Console.WriteLine($"Amount: {amount}, Payment Date: {paymentDate}, Staff ID: {staff_id}");
            Payment payment = new Payment();
            payment.payment_amount = amount;
            payment.payment_date = paymentDate;
            if(staff_id != 0) payment.staff_id = staff_id;
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
        public async Task<double> GetTodaysIncome()
        {
            DateTime today = DateTime.Today; // Gets today's date at 00:00:00

            var todaysIncome = await _context.Payment
                .Where(p => p.payment_date.HasValue &&
                       p.payment_date.Value.Date == today) // Filter payments for today
                .SumAsync(p => p.payment_amount); // Sum all amounts

            return todaysIncome ?? 0; // Return 0 if null (no payments today)
        }
        public async Task<Dictionary<string, double>> GetMonthlyIncome()
        {
            // Step 1: Fetch raw data from the database (grouped by Year & Month)
            var monthlyData = await _context.Payment
                .Where(p => p.payment_date.HasValue && p.payment_amount.HasValue)
                .GroupBy(p => new { p.payment_date.Value.Year, p.payment_date.Value.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalIncome = g.Sum(p => p.payment_amount.Value)
                })
                .ToListAsync(); // Execute the query and bring data to memory

            // Step 2: Format the month names on the client side
            var monthlyIncome = monthlyData
                .ToDictionary(
                    x => new DateTime(x.Year, x.Month, 1).ToString("MMMM yyyy"), // "May 2025"
                    x => x.TotalIncome
                );

            return monthlyIncome;
        }


    }
}
