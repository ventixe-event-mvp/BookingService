namespace BookingService.Models;

public class Booking
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = null!;
    public  int EventId { get; set; }

    public DateTime BookingDate { get; set; } = DateTime.Now;

}
