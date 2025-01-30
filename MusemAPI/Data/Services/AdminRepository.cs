
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using MuseumAPI.Data;
using MuseumAPI.Data.Models;


namespace tryfour.Repositories
{
    public class AdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> GetByUsernameAsync(string username)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Username == username);
        }

        public async Task AddAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }
    }
}
