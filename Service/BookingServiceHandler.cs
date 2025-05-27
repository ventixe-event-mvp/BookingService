using BookingService.Data;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Service;

public class BookingServiceHandler
{
    private readonly BookingDbContext _context;
    public BookingServiceHandler(BookingDbContext context)
    {
        _context = context;
    }

    //Hämta alla 
    public async Task<IEnumerable<Booking>> GetBookingsAsync()
    {
        return await _context.Bookings.ToListAsync();
    }

    //Skapa en ny bokning
    public async Task<Booking> CreateAsync(Booking booking)
    {
      
        booking.Id = Guid.NewGuid();
        booking.BookingDate = DateTime.Now;

        _context.Bookings.Add(booking);
         await _context.SaveChangesAsync();
        return booking;
    }


}
