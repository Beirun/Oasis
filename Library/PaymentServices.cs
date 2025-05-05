
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

        //private void getReceipt()
        //{
        //    String text = "PARKING RECEIPT";
        //    int intWidth = 600;
        //    int intHeight = 1000;

        //    bmp = new Bitmap(intWidth, intHeight);
        //    Graphics g = Graphics.FromImage(bmp);
        //    g.Clear(Color.White);
        //    g.SmoothingMode = SmoothingMode.HighQuality;
        //    g.TextRenderingHint = TextRenderingHint.AntiAlias;

        //    Brush brush = new SolidBrush(Color.Black);
        //    Font font = new Font("Cascadia Code", 50, FontStyle.Bold, GraphicsUnit.Pixel);
        //    SizeF size = g.MeasureString(text, font);
        //    Pen pen = new Pen(Color.Black, 4);
        //    using (Image image = Image.FromFile("C:\\Users\\Beirun\\source\\repos\\ParkInParkOut\\ParkInParkOut\\Resources\\parknabaireceipt.png"))
        //    {
        //        g.DrawImage(image, new Point(image.Width / 2, 25));
        //    }
        //    g.DrawLine(pen, 25, 245 - size.Height, 575, 245 - size.Height);
        //    g.DrawLine(pen, 25, 225 + size.Height, 575, 225 + size.Height);
        //    g.DrawString(text, font, brush, (intWidth - size.Width) / 2, 210, StringFormat.GenericDefault);

        //    font = new Font("Cascadia Code", 20, FontStyle.Regular, GraphicsUnit.Pixel);
        //    g.DrawString("PARK IN TIME", font, brush, 25, 350, StringFormat.GenericDefault);
        //    g.DrawString(parkInTime.ToString().ToUpper(), font, brush, getXPosition(g, parkInTime.ToString().ToUpper(), font), 350, StringFormat.GenericDefault);

        //    g.DrawString("PARK OUT TIME", font, brush, 25, 410, StringFormat.GenericDefault);
        //    g.DrawString(parkOutTime.ToString().ToUpper(), font, brush, getXPosition(g, parkOutTime.ToString().ToUpper(), font), 410, StringFormat.GenericDefault);

        //    g.DrawString("PLATE NUMBER", font, brush, 25, 470, StringFormat.GenericDefault);
        //    g.DrawString(plateNumber.ToUpper(), font, brush, getXPosition(g, plateNumber.ToUpper(), font), 470, StringFormat.GenericDefault);

        //    g.DrawString("VEHICLE TYPE", font, brush, 25, 530, StringFormat.GenericDefault);
        //    g.DrawString(vehicleType.ToUpper(), font, brush, getXPosition(g, vehicleType.ToUpper(), font), 530, StringFormat.GenericDefault);

        //    g.DrawString("VEHICLE BRAND", font, brush, 25, 590, StringFormat.GenericDefault);
        //    g.DrawString(vehicleBrand.ToUpper(), font, brush, getXPosition(g, vehicleBrand.ToUpper(), font), 590, StringFormat.GenericDefault);

        //    g.DrawString("PARKING SLOT", font, brush, 25, 650, StringFormat.GenericDefault);
        //    g.DrawString(parkingSlot.ToUpper(), font, brush, getXPosition(g, parkingSlot.ToUpper(), font), 650, StringFormat.GenericDefault);
        //}


    }
}
