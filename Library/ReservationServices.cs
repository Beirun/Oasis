
using Microsoft.EntityFrameworkCore;
using Oasis.Data;
using Oasis.Data.Models;
namespace Oasis.Library
{
    public class ReservationServices
    {
        private readonly AppDbContext _context;
        public ReservationServices( AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            return await _context.Reservation.ToListAsync();
        }

        public async Task<bool> AddReservation(DateOnly checkInDate, DateOnly checkOutDate, int guestId, int paymentId, string roomType)
        {
            List<Room> rooms = await _context.Room.Where(r => r.roomtype!.type_category == roomType && r.room_status == "Available").ToListAsync();

            int roomId = rooms[new Random().Next(rooms.Count)].room_id;
            Reservation reservation = new Reservation();
            reservation.rsv_checkin = checkInDate;
            reservation.rsv_checkout = checkOutDate;
            reservation.guest_id = guestId;
            reservation.payment_id = paymentId;
            reservation.rsv_status = "Booked";
            reservation.room_id = roomId;
            _context.Reservation.Add(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}
