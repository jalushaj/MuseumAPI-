using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MuseumAPI.Data.Services;

namespace tryfour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("create", Name = "create")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDTO newBooking)
        {
            try
            {
                await _bookingService.AddAsync(newBooking);
                return Ok("Booking created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("view", Name = "view")]
        public async Task<IActionResult> ViewBookings()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }
    }
}
