namespace BookingService.Models;

public class Booking
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; } 
    public  int EventId { get; set; }

    public DateTime BookingDate { get; set; } = DateTime.Now;

}
