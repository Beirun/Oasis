
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
            //get reservation where room_id of reservation is equal to room_id of Room, and guest_id of reservation is equal to user_id of User
            var bookings = await _context.Reservation
                        .Include(r => r.room)
                            .ThenInclude(room => room.roomtype)
                        .Include(r => r.guest)
                            .ThenInclude(g => g.user)
                        .Where(r => r.room != null && r.guest != null)
                        .Select(r => new Booking
                        {
                            rsv_id = r.rsv_id,
                            user_email = r.guest.user.user_email,
                            user_fname = r.guest.user.user_fname,
                            user_lname = r.guest.user.user_lname,
                            room_no = r.room.room_no ?? 0,
                            type_category = r.room.roomtype.type_category,
                            rsv_checkin = r.rsv_checkin ?? default,
                            rsv_checkout = r.rsv_checkout ?? default,
                            rsv_status = r.rsv_status
                        })
                        .ToListAsync();
            return bookings;
        }

        public async Task<bool> AddReservation(DateOnly checkInDate, DateOnly checkOutDate, int guestId, int roomId, int paymentId)
        {
            //List<Room> rooms = await _context.Room.Where(r => r.roomtype!.type_category == roomType && r.room_status == "Available").ToListAsync();

            //int roomId = rooms[new Random().Next(rooms.Count)].room_id;
            Reservation reservation = new Reservation();
            reservation.rsv_checkin = checkInDate;
            reservation.rsv_checkout = checkOutDate;
            reservation.guest_id = guestId;
            reservation.room_id = roomId;
            reservation.payment_id = paymentId;
            reservation.rsv_status = "Booked";
            _context.Reservation.Add(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
        // Add this method to ReservationServices.cs
        public async Task<List<GuestBooking>> GetReservationsByGuestId(int guestId)
        {
            var bookings = await _context.Reservation
                .Include(r => r.room)
                    .ThenInclude(room => room.roomtype)
                .Include(r => r.payment)
                .Where(r => r.guest_id == guestId && r.room != null && r.payment != null)
                .Select(r => new GuestBooking
                {
                    rsv_id = r.rsv_id,
                    room_no = r.room.room_no ?? 0,
                    type_category = r.room.roomtype.type_category ?? string.Empty,
                    rsv_checkin = r.rsv_checkin ?? default,
                    rsv_checkout = r.rsv_checkout ?? default,
                    rsv_status = r.rsv_status ?? string.Empty,
                    payment_amount = r.payment.payment_amount ?? 0
                })
                .ToListAsync();

            return bookings;
        }

    }
}
