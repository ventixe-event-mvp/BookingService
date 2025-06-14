﻿using BookingService.Data;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;
// koden skriven i samarbete med chatGPT
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
    //Hämta  bokning för användare  (id)
    public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(Guid userId)
    {
        return await _context.Bookings
            .Where(b => b.UserId == userId)
            .ToListAsync();
    }
}
