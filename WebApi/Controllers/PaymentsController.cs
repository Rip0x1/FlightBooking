using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly FlightDbContext _context;

        public PaymentsController(FlightDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments
                .Include(p => p.Booking)
                .ThenInclude(b => b.User)
                .Include(p => p.Booking)
                .ThenInclude(b => b.Flight)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.Booking)
                .ThenInclude(b => b.User)
                .Include(p => p.Booking)
                .ThenInclude(b => b.Flight)
                .FirstOrDefaultAsync(p => p.PaymentId == id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment([FromBody] Payment payment)
        {
            System.Diagnostics.Debug.WriteLine($"Received Payment: {Newtonsoft.Json.JsonConvert.SerializeObject(payment)}");
            if (payment.BookingId <= 0 || payment.Amount <= 0 || string.IsNullOrEmpty(payment.Status))
            {
                return BadRequest("BookingId, Amount и Status обязательны.");
            }

            var booking = await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Flight)
                .FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
            if (booking == null)
            {
                return BadRequest("Бронь не найдена.");
            }

            var newPayment = new Payment
            {
                BookingId = payment.BookingId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod ?? "Кредитная карта",
                Status = payment.Status,
                Booking = booking
            };
            _context.Payments.Add(newPayment);
            await _context.SaveChangesAsync();

            var createdPayment = await _context.Payments
                .Include(p => p.Booking)
                .ThenInclude(b => b.User)
                .Include(p => p.Booking)
                .ThenInclude(b => b.Flight)
                .FirstOrDefaultAsync(p => p.PaymentId == newPayment.PaymentId);

            return CreatedAtAction(nameof(GetPayment), new { id = createdPayment.PaymentId }, createdPayment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payment payment)
        {
            System.Diagnostics.Debug.WriteLine($"Received Payment: {Newtonsoft.Json.JsonConvert.SerializeObject(payment)}");
            if (id != payment.PaymentId || payment.BookingId <= 0 || payment.Amount <= 0 || string.IsNullOrEmpty(payment.Status))
            {
                return BadRequest("PaymentId, BookingId, Amount и Status обязательны.");
            }

            var existingPayment = await _context.Payments.FindAsync(id);
            if (existingPayment == null)
            {
                return NotFound();
            }

            existingPayment.BookingId = payment.BookingId;
            existingPayment.Amount = payment.Amount;
            existingPayment.PaymentDate = payment.PaymentDate;
            existingPayment.PaymentMethod = payment.PaymentMethod ?? "Кредитная карта";
            existingPayment.Status = payment.Status;

            var booking = await _context.Bookings
                .Include(b => b.User)
                .Include(b => b.Flight)
                .FirstOrDefaultAsync(b => b.BookingId == payment.BookingId);
            if (booking == null)
            {
                return BadRequest("Бронь не найдена.");
            }
            existingPayment.Booking = booking;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentId == id);
        }
    }
}