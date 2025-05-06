
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
using Oasis.Data.Object;
namespace Oasis.Library
{
    public class ReservationServices
    {
        private readonly AppDbContext _context;
        public ReservationServices( AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetReservations()
        {
            var bookings = await _context.Reservation
                    .Include(r => r.payment)
                    .Include(r => r.room)
                        .ThenInclude(room => room.roomtype)
                    .Include(r => r.guest)
                        .ThenInclude(g => g.user)
                    .Where(r => r.room != null && r.guest != null && r.payment != null)
                    .Select(r => new Booking
                    {
                        rsv_id = r.rsv_id,
                        user_id = r.guest.user.user_id,
                        user_email = r.guest.user.user_email,
                        user_fname = r.guest.user.user_fname,
                        user_lname = r.guest.user.user_lname,
                        room_no = r.room.room_no ?? 0,
                        type_category = r.room.roomtype.type_category,
                        rsv_checkin = r.rsv_checkin ?? default,
                        rsv_checkout = r.rsv_checkout ?? default,
                        rsv_status = r.rsv_status,
                        payment_amount = r.payment.payment_amount ?? 0
                    })
                    .ToListAsync();

            foreach (var booking in bookings)
            {
                Console.WriteLine($"Bookings: {System.Text.Json.JsonSerializer.Serialize(booking)}");
            }

            return bookings;
        }

        public async Task<bool> AddReservation(string method,DateOnly checkInDate, DateOnly checkOutDate, int guestId, int roomId, int paymentId)
        {
            try
            {
                //List<Room> rooms = await _context.Room.Where(r => r.roomtype!.type_category == roomType && r.room_status == "Available").ToListAsync();

                //int roomId = rooms[new Random().Next(rooms.Count)].room_id;
                Console.WriteLine($"Method: {method}");
                Console.WriteLine($"Check In: {checkInDate}");

                Console.WriteLine($"Check Out: {checkOutDate}");
                Console.WriteLine($"Guest Id: {guestId}");

                Console.WriteLine($"Room Id: {roomId}");

                Console.WriteLine($"Payment Id: {paymentId}");

                Room room = await _context.Room.FirstOrDefaultAsync(r => r.room_id == roomId);
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(room));
                room.room_status = method == "walkin" ? "Unavailable" : "Reserved";
                Reservation reservation = new Reservation();
                reservation.rsv_checkin = checkInDate;
                reservation.rsv_checkout = checkOutDate;
                reservation.guest_id = guestId;
                reservation.room_id = roomId;
                reservation.payment_id = paymentId;
                reservation.rsv_status = method == "walkin" ? "Checked In" : "Booked";

                Console.WriteLine($"Reservation: {System.Text.Json.JsonSerializer.Serialize(reservation)}");
                _context.Reservation.Add(reservation);
                Console.WriteLine($"Reservation 2: {System.Text.Json.JsonSerializer.Serialize(reservation)}");
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        // Add this method to ReservationServices.cs
        public async Task<List<GuestBooking>> GetReservationsByGuestId(int guestId)
        {
            var bookings = await _context.Reservation
                .Include(r => r.room)
                    .ThenInclude(room => room.roomtype)
                .Include(r => r.payment)
                .Include(r => r.review)
                .Where(r => r.guest_id == guestId && r.room != null && r.payment != null)
                .Select(r => new GuestBooking
                {
                    rsv_id = r.rsv_id,
                    room_no = r.room.room_no ?? 0,
                    review_id = r.review != null ? r.review.review_id : 0,
                    type_category = r.room.roomtype.type_category ?? string.Empty,
                    rsv_checkin = r.rsv_checkin ?? default,
                    rsv_checkout = r.rsv_checkout ?? default,
                    rsv_status = r.rsv_status ?? string.Empty,
                    payment_amount = r.payment.payment_amount ?? 0
                })
                .ToListAsync();

            return bookings;
        }
        public async Task UpdateReservationStatus(int rsvId, string status)
        {
            var reservation = await _context.Reservation.FirstOrDefaultAsync(r => r.rsv_id == rsvId);
            var room = await _context.Room.FirstOrDefaultAsync(r => r.room_id == reservation.room_id);
            if (reservation != null)
            {
                reservation.rsv_status = status;
                if(status == "Checked Out")
                {
                    if (room != null)
                    {
                        room.room_status = "Needs Cleaning";
                    }
                }else if(status == "Checked In")
                {
                    room.room_status = "Unavailable";
                }
                else if (status == "Cancelled")
                {
                    room.room_status = "Available";
                }

                    await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExtendReservation(int reservationId, DateOnly newCheckOutDate, double additionalAmount)
        {
            try
            {
                // Get the existing reservation
                var reservation = await _context.Reservation
                    .Include(r => r.room)
                    .Include(r => r.payment)
                    .FirstOrDefaultAsync(r => r.rsv_id == reservationId);

                if (reservation == null)
                {
                    Console.WriteLine($"Reservation with ID {reservationId} not found");
                    return false;
                }


                // Update the reservation with new checkout date and add the new payment
                reservation.rsv_checkout = newCheckOutDate;

                // If you want to track the original payment and the extension payment separately,
                // you might need to modify your database schema to support multiple payments per reservation.
                // For now, we'll just update the original payment amount by adding the additional amount
                reservation.payment.payment_amount += additionalAmount;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extending reservation: {ex.Message}");
                return false;
            }
        }

    }
}
