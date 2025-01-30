using MuseumAPI.Data.DTOs;
using tryfour.Repositories;
using System.Threading.Tasks;
using MuseumAPI.Data.Models;

namespace MuseumAPI.Data.Services
{
    public class AdminService
    {
        private readonly AdminRepository _repository;

        public AdminService(AdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ValidateAdmin(AdminDTO adminDTO)
        {
            var admin = await _repository.GetByUsernameAsync(adminDTO.Username);
            return admin != null && admin.Password == adminDTO.Password;
        }

        public async Task AddAdminAsync(AdminDTO adminDTO)
        {
            var admin = new Admin
            {
                Username = adminDTO.Username,
                Password = adminDTO.Password 
            };
            await _repository.AddAsync(admin);
        }
    }
}
