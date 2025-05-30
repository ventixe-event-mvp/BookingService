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

   
    [HttpGet]
    public async Task<IActionResult> GetBookings()
    {
        var bookings = await _bookingServiceHandler.GetBookingsAsync();
        return Ok(bookings);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetBookingsByUser(Guid userId)
    {
       var bookings = await _bookingServiceHandler.GetBookingsByUserIdAsync(userId);
        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var created = await _bookingServiceHandler.CreateAsync(booking);
        return Ok(created);


        
    }
}
