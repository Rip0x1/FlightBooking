namespace FlightBooking.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int FlightId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
        public string PassengerName { get; set; } 
        public Flight Flight { get; set; }
        public User User { get; set; }
    }
}