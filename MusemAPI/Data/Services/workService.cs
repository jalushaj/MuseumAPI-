using Microsoft.EntityFrameworkCore;
using MuseumAPI.Data.Models;
using Projekti.Models;
namespace MuseumAPI.Data.Services
   
{
    public class workService
    {
        private readonly AppDbContext _context;

        public workService(AppDbContext context)
        {
            _context = context;
        }

        // Get all works
        public async Task<List<workModel>> GetAllWorksAsync()
        {
            return await _context.Work.ToListAsync();
        }

        // Add a new work
        public async Task AddWorkAsync(workModel work)
        {
            _context.Work.Add(work);
            await _context.SaveChangesAsync();
        }

        // Update a work
        public async Task UpdateWorkAsync(workModel work)
        {
            _context.Work.Update(work);
            await _context.SaveChangesAsync();
        }

        // Delete a work
        public async Task DeleteWorkAsync(int id)
        {
            var work = await _context.Work.FindAsync(id);
            if (work != null)
            {
                _context.Work.Remove(work);
                await _context.SaveChangesAsync();
            }
        }



    }
}


