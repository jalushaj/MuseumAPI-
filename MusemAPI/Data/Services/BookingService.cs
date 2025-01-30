
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MuseumAPI.Data.Models;

namespace MuseumAPI.Data.Services
{
    public class BookingService
    {
        private readonly BookingRepository _repository;

        public BookingService(BookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookingDTO>> GetAllAsync()
        {
            var bookings = await _repository.GetAllAsync();
            return bookings.Select(b => new BookingDTO
            {
                Name = b.Name,
                Surname = b.Surname,
                Event = b.Event,
                Date = b.Date,
                Adults = b.Adults,
                Kids = b.Kids,
                Card = b.Card
            }).ToList();
        }
        public async Task<BookingDTO> GetByIdAsync(int id)
        {
            var booking = await _repository.GetByIdAsync(id);
            if (booking == null) return null;

            return new BookingDTO
            {
                Name = booking.Name,
                Surname = booking.Surname,
                Event = booking.Event,
                Date = booking.Date,
                Adults = booking.Adults,
                Kids = booking.Kids,
                Card = booking.Card
            };
        }

        public async Task UpdateAsync(int id, BookingDTO bookingDTO)
        {
            var booking = await _repository.GetByIdAsync(id);
            if (booking == null) return;

            booking.Name = bookingDTO.Name;
            booking.Surname = bookingDTO.Surname;
            booking.Event = bookingDTO.Event;
            booking.Date = bookingDTO.Date;
            booking.Adults = bookingDTO.Adults;
            booking.Kids = bookingDTO.Kids;
            booking.Card = bookingDTO.Card;

            await _repository.UpdateAsync(booking);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task AddAsync(BookingDTO bookingDTO)
        {
            var booking = new Booking
            {
                Name = bookingDTO.Name,
                Surname = bookingDTO.Surname,
                Event = bookingDTO.Event,
                Date = bookingDTO.Date,
                Adults = bookingDTO.Adults,
                Kids = bookingDTO.Kids,
                Card = bookingDTO.Card
            };

            await _repository.AddAsync(booking);
        }
    }
}

