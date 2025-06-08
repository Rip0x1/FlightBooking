using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly FlightDbContext _context;

        public BookingsController(FlightDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings
                .Include(b => b.Flight)
                .Include(b => b.User)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking([FromBody] BookingRequest bookingRequest)
        {
            if (bookingRequest == null || bookingRequest.FlightId <= 0 || bookingRequest.UserId <= 0)
            {
                return BadRequest(new { errors = new[] { "User and Flight fields are required." } });
            }

            var flight = await _context.Flights.FindAsync(bookingRequest.FlightId);
            if (flight == null || flight.AvailableSeats <= 0)
                return BadRequest("Рейс не найден или нет свободных мест.");

            var user = await _context.Users.FindAsync(bookingRequest.UserId);
            if (user == null)
                return BadRequest("Клиент не найден.");

            var booking = new Booking
            {
                FlightId = bookingRequest.FlightId,
                UserId = bookingRequest.UserId,
                BookingDate = DateTime.Now,
                Status = "Подтверждено",
                PassengerName = user.FullName,
                Flight = flight,
                User = user
            };

            flight.AvailableSeats--;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingId }, booking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] Booking booking)
        {
            if (booking == null || booking.BookingId != id)
                return BadRequest();

            var existingBooking = await _context.Bookings.FindAsync(id);
            if (existingBooking == null)
                return NotFound();

            existingBooking.Status = booking.Status;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return NotFound("Бронь не найдена");

            var flight = await _context.Flights.FindAsync(booking.FlightId);
            if (flight != null)
                flight.AvailableSeats++;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    public class BookingRequest
    {
        public int FlightId { get; set; }
        public int UserId { get; set; }
    }
}