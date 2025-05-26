using BookingService.Data;
using BookingService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly BookingDbContext _context;

    public BookingController(BookingDbContext context)
    {
        _context = context;
    }

    //Hämta alla boknignar
    [HttpGet]
    public IActionResult GetBookings()
    {
        var bookings = _context.Bookings.ToList();
        return Ok(bookings);
    }

    [HttpPost]
    public IActionResult CreateBooking([FromBody] Booking booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        booking.Id = Guid.NewGuid();
        booking.BookingDate = DateTime.Now; 
       

        _context.Bookings.Add(booking);
        _context.SaveChanges();

        return Ok(booking);
    }
}
