
    using Microsoft.EntityFrameworkCore;
using MuseumAPI.Data.Models;


namespace MuseumAPI.Data.Services
{
    public class ExhibitionRepository
        {
            private readonly AppDbContext _context;

            public ExhibitionRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Exhibition>> GetAllAsync()
            {
                return await _context.Exhibitions.ToListAsync();
            }

            public async Task<Exhibition> GetByIdAsync(int id)
            {
                return await _context.Exhibitions.FindAsync(id);
            }

            public async Task AddAsync(Exhibition exhibition)
            {
                _context.Exhibitions.Add(exhibition);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Exhibition exhibition)
            {
                _context.Exhibitions.Update(exhibition);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var exhibition = await _context.Exhibitions.FindAsync(id);
                if (exhibition != null)
                {
                    _context.Exhibitions.Remove(exhibition);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
