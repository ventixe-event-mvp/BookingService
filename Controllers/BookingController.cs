using BookingService.Data;
using BookingService.Models;
using BookingService.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly BookingServiceHandler _bookingServiceHandler;

    public BookingController(BookingServiceHandler bookingServiceHandler)
    {
        _bookingServiceHandler = bookingServiceHandler;
    }

    //Hämta alla boknignar
    [HttpGet]
    public IActionResult GetBookings()
    {
        var bookings = _bookingServiceHandler.GetBookings();
        return Ok(bookings);
    }

    [HttpPost]
    public IActionResult CreateBooking([FromBody] Booking booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var created = _bookingServiceHandler.Create(booking);
        return Ok(created);


        
    }
}
