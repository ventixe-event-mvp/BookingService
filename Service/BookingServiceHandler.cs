using BookingService.Data;
using BookingService.Models;

namespace BookingService.Service;

public class BookingServiceHandler
{
    private readonly BookingDbContext _context;
    public BookingServiceHandler(BookingDbContext context)
    {
        _context = context;
    }

    //Hämta alla 
    public IEnumerable<Booking> GetBookings()
    {
        return _context.Bookings.ToList();
    }

    //Skapa en ny bokning
    public Booking Create(Booking booking)
    {
      
        booking.Id = Guid.NewGuid();
        booking.BookingDate = DateTime.Now;

        _context.Bookings.Add(booking);
        _context.SaveChanges();
        return booking;
    }


}
