using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MuseumAPI.Data.Services;
namespace tryfour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public AdminController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("view")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDTO updatedBooking)
        {
            var existingBooking = await _bookingService.GetByIdAsync(id);
            if (existingBooking == null)
                return NotFound("Booking not found.");

            await _bookingService.UpdateAsync(id, updatedBooking);
            return Ok("Booking updated successfully.");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var existingBooking = await _bookingService.GetByIdAsync(id);
            if (existingBooking == null)
                return NotFound("Booking not found.");

            await _bookingService.DeleteAsync(id);
            return Ok("Booking deleted successfully.");
        }
    }
}
